# Mandelbrot_Chaos_graph
 petite expérimentation en C# sur les fractales
 
 ## Fonctionnement de l'algorithme de Mandelbrot :
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
