# Classes D'Equivalència #

## Mètodes Globals ##

### Validar Opcions Menús ###

|  Domini    |     Classe     |  Tipus  | Resultat | Límit Inferior | Límit Superior |
|------------|----------------|---------|----------|----------------|----------------|
| Strings    |  [a, b, c, d]  | Vàlida  |  TRUE    |        a       |        d       |
| Strings    |     Other      | Vàlida  |  FALSE   |       a        |     Cell 6     |

### Validar Intents ###

|  Domini    |     Classe     |  Tipus  | Resultat | Límit Inferior | Límit Superior |
|------------|----------------|---------|----------|----------------|----------------|
|  Enters    |   (-inf, 0]    | Vàlida  |  FALSE   |     -inf.      |        0       |
|  Enters    |   [1, +inf)    | Vàlida  |  TRUE    |       1        |     +inf.      |

### Comprovar Fi de Programa ###

|  Domini    |     Classe     |  Tipus  | Resultat | Límit Inferior | Límit Superior |
|------------|----------------|---------|----------|----------------|----------------|
| Strings    |        b       | Vàlida  |  TRUE    |        b       |        b       |
| Strings    |     Other      | Vàlida  |  FALSE   |        a       |        c       |

### Generar Random Min i Max ###

|  Domini    |     Classe               |  Tipus  |              Resultat              | Límit Inferior | Límit Superior |
|------------|--------------------------|---------|------------------------------------|----------------|----------------|
|  Enters    |(-inf, num2) (num1, +inf) | Vàlida  |  num entre els valors introduïts   |-inf. / num1 + 1|num2 - 1 / +inf.|
|  Enters    |[num2, +inf) (-inf, num1] | Invàlida|               ERROR                |  num2 / -inf.  |  +inf. / num1  |

### Generar Random Max ###

|  Domini    |  Classe   |  Tipus  |              Resultat              | Límit Inferior | Límit Superior |
|------------|-----------|---------|------------------------------------|----------------|----------------|
|  Enters    | [1, +inf) | Vàlida  |  num entre els valors introduïts   |       1        |      +inf.     |
|  Enters    | (-inf, 0) | Invàlida|               ERROR                |     -inf.      |        0       |

### Moure valor d'array a posició indicada ###

|Domini|                  Classe                           | Tipus  |    Resultat    |Límit Inferior|Límit Superior     |
|------|---------------------------------------------------|--------|----------------|--------------|-------------------|
|Enters|Nums que conté l'array / [0, mida de l'array - 1]  |Vàlida  |Canvi de posició|      0       |mida de l'array - 1|
|Enters|    Nums que no conté l'array / [-inf, -1]         |Invàlida|   ERROR        |   -inf.      |         -1        |
|Enters|Nums que no conté l'array / [-inf, mida de l'array]|Invàlida|   ERROR        |   -inf.      |  mida de l'array  |

### Validar Vida ###

|  Domini    |     Classe     |  Tipus  | Resultat | Límit Inferior | Límit Superior |
|------------|----------------|---------|----------|----------------|----------------|
|  Enters    |   (-inf, 0]    | Vàlida  |  FALSE   |     -inf.      |        0       |
|  Enters    |   [1, +inf)    | Vàlida  |  TRUE    |       1        |     +inf.      |

### Validar Intents ###

|       Domini        |     Classe       |  Tipus  | Resultat | Límit Inferior  |   Límit Superior  |
|---------------------|------------------|---------|----------|-----------------|-------------------|
|  Enters i Strings   | other / (-inf, 0]| Vàlida  |  FALSE   |   a /  -inf.    |      d /  0       |
|  Enters i Strings   |   c / [1, +inf)  | Vàlida  |  TRUE    |   c  /  1       |    c / +inf.      |

### Validar Vida ###

|  Domini    |     Classe     |  Tipus  | Resultat | Límit Inferior | Límit Superior |
|------------|----------------|---------|----------|----------------|----------------|
|  Enters    |   (-inf, 0]    | Vàlida  |  FALSE   |     -inf.      |        0       |
|  Enters    |   [1, +inf)    | Vàlida  |  TRUE    |       1        |     +inf.      |

### Calcular Atac ###

|  Domini    |     Classe               |  Tipus  | Resultat | Límit Inferior | Límit Superior |
|------------|--------------------------|---------|----------|----------------|----------------|
|   Enters   | (-inf, -1] / [101, +inf) | Vàlida  |Incorrecte|     -inf. / 101     |        -1 / +inf       |
|   Enters   | (-inf, -1] / (-inf, -1]  | Vàlida  |Incorrecte|     -inf. / -inf.      |        -1 / -1       |
|   Enters   | [0, +inf)  / [0, 100]    | Vàlida  | Correcte |       0 / 0        |     +inf. / 100      |

### Calcular Probabilitat ###

|  Domini    |    Classe   |   Tipus   | Resultat | Límit Inferior | Límit Superior |
|------------|-------------|-----------|----------|----------------|----------------|
|   Enters   | [101, +inf) | Invàlida  |  ERROR   |      101       |     +inf       |
|   Enters   | (-inf, -1]  | Invàlida  |  ERROR   |     -inf.      |      -1        |
|   Enters   | [0, 100]    |  Vàlida   |TRUE/FALSE|       0        |      100       |

### Validar Overhealing ###

|  Domini    |     Classe               |  Tipus  |  Resultat   | Límit Inferior | Límit Superior |
|------------|--------------------------|---------|-------------|----------------|----------------|
|  Enters    |(-inf, num2) (num1, +inf) | Vàlida  |    TRUE     |-inf. / num1 + 1|num2 - 1 / +inf.|
|  Enters    |[num2, +inf) (-inf, num1] | Vàlida|   FALSE     |  num2 / -inf.  |  +inf. / num1  |

### Validar Stun Monstre ###

|  Domini    |     Classe     |  Tipus  | Resultat | Límit Inferior | Límit Superior |
|------------|----------------|---------|----------|----------------|----------------|
|  Enters    |   (-inf, 0]    | Vàlida  |  FALSE   |     -inf.      |        0       |
|  Enters    |   [1, +inf)    | Vàlida  |  TRUE    |       1        |     +inf.      |

### Validar Skill Bàrbar ###

|  Domini    |     Classe     |  Tipus  | Resultat | Límit Inferior | Límit Superior |
|------------|----------------|---------|----------|----------------|----------------|
|  Enters    |   (-inf, 0]    | Vàlida  |  FALSE   |     -inf.      |        0       |
|  Enters    |   [1, +inf)    | Vàlida  |  TRUE    |       1        |     +inf.      |

### Validar Format Noms ###

|  Domini    |     Classe     |  Tipus  | Resultat | Límit Inferior | Límit Superior |
|------------|----------------|---------|----------|----------------|----------------|
|  Strings    |sense simbols i 4 noms| Vàlida  |  TRUE   |  pol,hugo,pablo,silvia         |   pol,hugo,pablo,silvia    |
|  Strings    |Conté símbols| Vàlida  |  FALSE    | pol,hugo,pablo,silvia?  |     +pol,hugo,pablo,silvia.      |
|  Strings    |Més de 4 noms| Vàlida  |  FALSE    |pol,hugo,pablo,silvia,antonio |  pol,hugo,pablo,silvia,antonio...  |
|  Strings    |Menys de 4 noms| Vàlida  |  FALSE    |   -------    |     pol,hugo,pablo      |

### Validar Rang Stats ###

|  Domini    |     Classe               |  Tipus  |  Resultat   | Límit Inferior | Límit Superior |
|------------|--------------------------|---------|-------------|----------------|----------------|
|  Enters    |(-inf, num2) (num1, +inf) (num1, num2)| Vàlida  | TRUE |-inf. / num1 + 1 / num1 + 1|  num2 - 1 / +inf. / +inf.  |
|  Enters    |[num2, +inf) (-inf, num1] (-inf, +inf)| Invàlida|ERROR|  num2 / -inf. / -inf.  |  +inf. / num1 / +inf.  |
|  Enters    |(-inf, num2) (num1, +inf) (-inf, num1 - 1)| Vàlida  |FALSE|-inf. / num1 + 1 / -inf - 1|  num2 - 1 / +inf. / num 1 - 1  |
|  Enters    |(-inf, num2) (num1, +inf) (num2 + 1, +inf)| Vàlida  |FALSE|-inf. / num1 + 1 / num2 + 1|  num2 - 1 / +inf. / +inf + 1.  |

### Assignar Nom Missatge ###

|  Domini    |     Classe               |  Tipus  |  Resultat   | Límit Inferior | Límit Superior |
|------------|--------------------------|---------|-------------|----------------|----------------|
|  Enters    | [1, 1]  | Vàlida    | Arquer |  1  |  1  |
|  Enters    | [2, 2]  | Vàlida    | Bàrbar |  2  | 2  |
|  Enters    | [3, 3]  | Vàlida    | Mag |  3  |  3  |
|  Enters    | [4, 4]  | Vàlida    | Druida |  4  |  4  |
|  Enters    | (-inf, 0]  | Invàlida  |ERROR|  -inf  |  0  |
|  Enters    |[5, +inf)  | Invàlida  |ERROR|  5 |  +inf |

### Assignar Stat Missatge ###

|  Domini    |     Classe               |  Tipus  |  Resultat   | Límit Inferior | Límit Superior |
|------------|--------------------------|---------|-------------|----------------|----------------|
|  Enters    | [1, 1]  | Vàlida    | vida |  1  |  1  |
|  Enters    | [2, 2]  | Vàlida    | atac |  2  | 2  |
|  Enters    | [3, 3]  | Vàlida    | defensa |  3  |  3  |
|  Enters    | (-inf, 0]  | Invàlida  |ERROR|  -inf  |  0  |
|  Enters    |[4, +inf)  | Invàlida  |ERROR|  4 |  +inf |
