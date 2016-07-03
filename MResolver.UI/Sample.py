
#GPLK
# supply{i in I}: a[i] = sum{j in J} X[i,j] ;

#for t in TIME:
#    for k in MACHINES:
#        R[k,t]=sum( { X[i,t]*res[i,k0] for (i,k0) in ITEMS_MACHINES if k==k0 } )


#SETS
TIME = {1, 2, 3, 4, 5}
ITEMS = { 'P1', 'P2' }
MACHINES = {'Linea1', 'Linea2', 'Linea3'}

#def: ITEMS_MACHINES => over (ITEMS, MACHINES)

ITEMS_MACHINES = { ('P1', 'Linea1'),
                   ('P1', 'Linea2'),
                   ('P2', 'Linea2'),
                   ('P2', 'Linea3') }

#VARIABLES
#def: 

res['P1','Linea1'] = 14;
res['P1','Linea2'] = 7;
res['P2','Linea2'] = 15;
res['P2','Linea3'] = 20.5;

X['P1',1] = 200;
X['P1',2] = 1600;
X['P1',3] = 65;
X['P1',4] = 150;
X['P1',5] = 168;

X['P2',1] = 158;
X['P2',2] = 3290;
X['P2',3] = 3290;
X['P2',4] = 0;
X['P2',5] = 0;


for t in TIME:
    for k in MACHINES:
        R[k,t]=sum( { X[i,t]*res[i,k0] for (i,k0) in ITEMS_MACHINES if k==k0 } )


# --> future syntax with all keys quantifier (slicing)
#for t in TIME:
#    for k in MACHINES:
#        R[k,t]=sum( { X[i,t]*res[i,k] for (i,k) in ITEMS_MACHINES[:,k] } )






