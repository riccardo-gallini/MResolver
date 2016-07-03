using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.AddIn;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.SharpDevelop.Editor;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Windows.Media;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;

namespace MResolver.UI.CodeEditor
{
    public class ResolverCodeEditor : TextEditor
    {
        
        public ResolverCodeEditor() : base()
        {
            var textEditor = this;
            
            textEditor.ShowLineNumbers = false;
            textEditor.FontFamily = new FontFamily("Consolas");
            textEditor.FontSize = 12.75f;

            textEditor.TextArea.TextEntered += textEditor_TextArea_TextEntered;
            textEditor.TextArea.TextEntering += textEditor_TextArea_TextEntering;

            //Syntax highlighting -- Python.xshd
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "MResolver.UI.CodeEditor.Python.xshd";

            Stream xshd_stream = assembly.GetManifestResourceStream(resourceName);
            if (xshd_stream!=null)
            {
                XmlTextReader xshd_reader = new XmlTextReader(xshd_stream);
                
                textEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd_reader, HighlightingManager.Instance);
                xshd_reader.Close();
                xshd_stream.Close();
            }
            
            //Text marker <simple>
            InitializeTextMarkerService();

            //IconbarMargin
            var ma = new IconBarMargin(new IconBarManager());
            textEditor.TextArea.LeftMargins.Add(ma);

            //Indentation strategy
            //textEditor.TextArea.IndentationStrategy

        }

        #region TextMarkers

        ITextMarkerService textMarkerService;
        
        void InitializeTextMarkerService()
        {
            var textEditor = this;

            var textMarkerService = new TextMarkerService(textEditor.Document);
            textEditor.TextArea.TextView.BackgroundRenderers.Add(textMarkerService);
            textEditor.TextArea.TextView.LineTransformers.Add(textMarkerService);
            IServiceContainer services = (IServiceContainer)textEditor.Document.ServiceProvider.GetService(typeof(IServiceContainer));
            if (services != null)
                services.AddService(typeof(ITextMarkerService), textMarkerService);
            this.textMarkerService = textMarkerService;
        }

        bool IsSelected(ITextMarker marker)
        {
            var textEditor = this;

            int selectionEndOffset = textEditor.SelectionStart + textEditor.SelectionLength;
            if (marker.StartOffset >= textEditor.SelectionStart && marker.StartOffset <= selectionEndOffset)
                return true;
            if (marker.EndOffset >= textEditor.SelectionStart && marker.EndOffset <= selectionEndOffset)
                return true;
            return false;
        }

        #endregion

        #region Completion Window

        CompletionWindow completionWindow;


        void textEditor_TextArea_TextEntered(object sender, TextCompositionEventArgs e)
        {
            if (e.Text == ".")
            {
                // open code completion after the user has pressed dot:
                completionWindow = new CompletionWindow(this.TextArea);
                // provide AvalonEdit with the data:
                //IList<ICompletionData> data = completionWindow.CompletionList.CompletionData;
                //data.Add(new MyCompletionData("Item1"));
                //data.Add(new MyCompletionData("Item2"));
                //data.Add(new MyCompletionData("Item3"));
                //data.Add(new MyCompletionData("Another item"));
                completionWindow.Show();
                completionWindow.Closed += delegate {
                    completionWindow = null;
                };
            }
        }

        void textEditor_TextArea_TextEntering(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Length > 0 && completionWindow != null)
            {
                if (!char.IsLetterOrDigit(e.Text[0]))
                {
                    // Whenever a non-letter is typed while the completion window is open,
                    // insert the currently selected element.
                    completionWindow.CompletionList.RequestInsertion(e);
                }
            }
            // do not set e.Handled=true - we still want to insert the character that was typed
        }

        #endregion

    }
}