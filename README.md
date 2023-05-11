# Fonctionnement de l'algorithme de Mandelbrot :
 Il utilise l'algorithme standard de Mandelbrot sur une grille de pixels, avec chaque pixel correspondant à un point dans le plan complexe.
![image](https://github.com/MatBureau/Mandelbrot_Chaos_graph/assets/86561676/ac4c82ea-8ad4-455a-bb9e-378852e04a27)

### Initialisation :

Il crée une image de la même taille que le canvas où l'image de l'ensemble de Mandelbrot sera dessinée.
WriteableBitmap est une classe qui représente une Bitmap sur laquelle on peut écrire directement. C'est utile ici car l'algorithme de Mandelbrot nécessite un contrôle pixel par pixel.
Le tableau pixels est utilisé pour stocker les valeurs des pixels de l'image.

### Boucle principale :

Pour chaque pixel de l'image, il calcule un nombre complexe c correspondant à la position du pixel sur le plan complexe. Les variables offsetX, offsetY et zoomLevel sont utilisées pour contrôler le positionnement et le zoom de l'image.
Il initialise z à 0 et compte le nombre d'itérations nécessaires pour que la magnitude de z dépasse 2, ou jusqu'à ce que le nombre maximum d'itérations soit atteint (256 dans ce cas). L'algorithme de Mandelbrot dit que pour un point donné c sur le plan complexe, si la séquence commençant par z=0 et définie par z = z*z + c ne diverge jamais, alors c appartient à l'ensemble de Mandelbrot.

### Couleur des pixels :

l'algorithme utilise le nombre d'itérations comme couleur pour le pixel. Si la séquence a divergé rapidement, le pixel sera plus clair ; si elle a mis du temps à diverger, le pixel sera plus foncé. Si elle n'a jamais divergé (c'est-à-dire si c'est dans l'ensemble de Mandelbrot), le pixel sera noir.
Les pixels sont en format BGRA (Bleu, Vert, Rouge, Alpha), donc il définit tous les canaux R, G et B à la même valeur pour obtenir une teinte de gris. Le canal Alpha est mis à 255, ce qui signifie que le pixel est complètement opaque.
Affichage de l'image :

Il copie les valeurs du tableau de pixels dans le bitmap.
Ensuite, il crée un objet Image, lui donne le bitmap comme source et l'ajoute au canvas pour l'affichage. Le résultat est une image en niveaux de gris de l'ensemble de Mandelbrot.

# Suite logistique - Diagramme de bifurcation 

![image](https://github.com/MatBureau/Mandelbrot_Chaos_graph/assets/86561676/4b94921e-43ed-4da8-abd4-3fb1a58efacb)

graphique de la fonction x = r * x * (1-x) avec des sliders pouvant faire varier r et x :
![image](https://github.com/MatBureau/Mandelbrot_Chaos_graph/assets/86561676/297cb902-0824-46c4-8888-af0a03610948)

Ce code est destiné à générer et à afficher un diagramme de bifurcation. Un diagramme de bifurcation est un graphique qui représente les points stables d'une fonction en fonction d'un paramètre de contrôle. Dans ce cas, la fonction est la suite logistique x = r * x * (1 - x), qui est une fonction couramment utilisée en dynamique des populations où x représente la population initiale et r le taux de croissance.

### Initialisation :

Il crée une instance de PlotModel (un modèle de graphique de la bibliothèque OxyPlot) et la définit comme le contexte de données de la fenêtre. Cela permet d'afficher le graphique dans le contrôle de graphique OxyPlot dans le fichier XAML associé.
Il appelle la méthode GenerateBifurcation pour générer le diagramme de bifurcation.

### GenerateBifurcation :

Il crée une série de points de dispersion (ScatterSeries) qui contiendra les points du diagramme de bifurcation.
Il définit les paramètres du diagramme : les valeurs de départ et de fin du paramètre de contrôle r, le nombre de pas pour r, le nombre de pas pour x et le nombre de premières itérations à ignorer (car la fonction peut prendre un certain temps avant de se stabiliser).
Pour chaque valeur de r, il itère la fonction logistique un certain nombre de fois pour atteindre une valeur stable de x. Il enregistre ensuite les valeurs stables de x pour cette valeur de r en ajoutant un point à la série de dispersion.

### Affichage du graphique :

Il efface toutes les séries précédentes du modèle de graphique et y ajoute la nouvelle série de dispersion.
Il appelle InvalidatePlot(true) pour forcer le graphique à se redessiner avec les nouvelles données.
