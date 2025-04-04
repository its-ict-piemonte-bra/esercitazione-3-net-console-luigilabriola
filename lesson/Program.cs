using System.Buffers;

namespace lesson
{
    public class Program
    {
        /// <summary>
        /// The main entrypoint of your application.
        /// </summary>
        /// <param name="args">The arguments passed to the program</param>
        public static void Main(string[] args)
        {
            //LessonInformation();
            //Console.WriteLine();
            Console.WriteLine("Ora gli esercizi:");

            //int[] array = LoadArray(10);

            //Console.WriteLine("Esercizio1:");
            //Exercise1();

            //Console.WriteLine("Esercizio2:");
            //Exercise2();

            //Console.WriteLine("Esercizio3:");
            //Exercise3();

            //Console.WriteLine("Esercizio4:");
            //Exercise4();

            //Console.WriteLine("Esercizio5:");
            //Exercise5();

            Console.WriteLine("Esercizio6:");
            Exercise6();

            Console.ReadLine();
        }

        /// <summary>
        /// Carica un array di n celle, chiedendo in input
        /// tutti i valori
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static
            int[] LoadArray(int n)
        {
            if (n < 0)
            {
                Console.WriteLine($"N deve essere un numero positivo, {n} non lo è.");
                return new int[] { };
            }
            else
            {
                Console.WriteLine("Caricamento vettore di [n] elementi...");
                int[] array = new int[n];
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Inserisci il valore di {i}: ");
                    array[i] = Convert.ToInt32(Console.ReadLine());
                }
                return array;
            }
        }

        /// <summary>
        /// carica un array bi-dimensionale date colonne e righe, chiedendo in input
        /// tutti i valori
        /// </summary>
        /// <param name="rows">Il nymero di righe dell'array bi-dimensionale</param>
        /// <param name="columns">Il numero di colonne dell'array bi-dimensionale</param>
        /// <returns>L'array bi-dimensionale risultato</returns>
        private static int[,] LoadMatrix(int rows, int columns)
        {
            if (rows < 0 || columns < 0)
            {
                Console.WriteLine($"Righe e colonne devono essere un numero positivo.");
                return new int[,] { };
            }
            else
            {
                int[,] result = new int[rows, columns];
                for (int i = 0;i < rows; i++)
                {
                    for (int j = 0;j < columns;j++)
                    {
                        Console.WriteLine($"matrix[{i}, {j}] = ");
                        result[i,j] = Convert.ToInt32(Console.ReadLine());
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// carica un array bi-dimensionale date riga per riga, 
        /// </summary>
        /// <param name="matrix">L'array bi-dimensionale da stamapre a video</param>

        private static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            Console.WriteLine($"Stampa di una matrice con {rows} righe e {columns} colonne...");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Stampa gli elementi di un array, una per riga, mettendo anche
        /// le informazioni sull'indice.
        /// </summary>
        /// <param name="array">L'array da stampare a video</param>

        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Stampa di un array {array.Length} elementi...");
                Console.WriteLine($"array[{i}] -> {array[i]}");
            }
        }

        /// <summary>
        /// Copia gli elementi di un array caricato in input in un secondo array
        /// poi li stampa entrambi
        /// </summary>
        private static void Exercise1()
        {
            Console.WriteLine("Inserire N:");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arrayA = LoadArray(n);
            int[] arrayB = new int[n];
            int i;

            // copiamo arrayA dentro arrayB
            for (i=0; i<n; i++)
            {
                arrayB[i] = arrayA[i];
            }

            // stampiamo i 2 array
            Console.WriteLine("ArrayA");
            for (i = 0; i < n; i++)
            {
                Console.WriteLine($"array[{i}] -> {arrayA[i]}");
            }
            Console.WriteLine("ArrayB");
            for (i = 0; i < n; i++)
            {
                Console.WriteLine($"array[{i}] -> {arrayB[i]}");
            }
        }

        /// <summary>
        /// Copia gli elementi di un array caricato in input in un secondo array
        /// poi li stampa entrambi
        /// </summary>
        private static void Exercise2()
        {
            Console.WriteLine("Inserire N:");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arrayA = LoadArray(n);
            int[] arrayB = new int[n];
            int i;

            // copiamo arrayA dentro arrayB
            for (i = 0; i < n; i++)
            {
                arrayB[arrayB.Length-i-1] = arrayA[i];
            }

            // stampiamo i 2 array
            Console.WriteLine("ArrayA");
            for (i = 0; i < n; i++)
            {
                Console.WriteLine($"array[{i}] -> {arrayA[i]}");
            }
            Console.WriteLine("ArrayB");
            for (i = 0; i < n; i++)
            {
                Console.WriteLine($"array[{i}] -> {arrayB[i]}");
            }
        }
        /// <summary>
        /// Invertire gli elementi di un array, senza usare un secondo array.
        /// </summary>
        private static void Exercise3()
        {
            Console.WriteLine("Inserire N:");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arrayA = LoadArray(n);
            Console.WriteLine("Prima dell'inversione");
            PrintArray(arrayA);

            for (int i = 0; i < n/2; ++i)
            {
                int temp = arrayA[i];
                arrayA[i] = arrayA[n - i - 1];
                arrayA[n - i - 1] = temp;
            }
            Console.WriteLine("Dopo l'inversione:");
            PrintArray(arrayA);
        }

        /// <summary>
        /// Determina il valore maggiore e minore di un array in input
        /// </summary>
        private static void Exercise4()
        {
            Console.WriteLine("Inserire N:");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arrayA = LoadArray(n);

            if (n==0)
            {
                Console.WriteLine("Non posso trovare max e min di un array vuoto!");
            }
            else
            {
                int max = arrayA[0];
                int min = arrayA[0];

                for (int i = 1; i < n ; ++i)
                {
                    if (arrayA[i] > max)
                    {
                        max = arrayA[i];
                    }
                    if (arrayA[i] < min)
                    {
                        min = arrayA[i];
                    }
                }
                Console.WriteLine($"Il valore maggiore è {max}");
                Console.WriteLine($"Il valore minore è {min}");

            }

        }

        /// <summary>
        /// Calcolare la somma di due matrici richieste in input
        /// </summary>
        private static void Exercise5()
        {
            Console.WriteLine("Inserire il numero di colonne:");
            int columns = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Inserire il numero di righe:");
            int rows = Convert.ToInt32(Console.ReadLine());

            int[,] matrixA = LoadMatrix(rows, columns);
            int[,] matrixB = LoadMatrix(rows, columns);

            int[,] matrixResult = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrixResult[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }

            Console.WriteLine("Matrice somma:");
            PrintMatrix(matrixResult);
        }

        /// <summary>
        /// Conta il numero di occorrenze di un valore preso in input all'interno
        /// di un matrice presa in input.
        /// </summary>
        private static void Exercise6()
        {
            Console.WriteLine("Inserire il numero di colonne:");
            int columns = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Inserire il numero di righe:");
            int rows = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Inserire il valore da cercare:");
            int x = Convert.ToInt32(Console.ReadLine());

            int[,] matrix = LoadMatrix(rows, columns);

            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] == x)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine($"Il valore {x} compare esattamente {count} volte della matrice");
        }

        /// <summary>
        /// Copia gli elementi di un array caricato in input in un secondo array
        /// invertendoli epoi li stampa entrambi
        /// </summary>

        private static void LessonInformation()
        {
            Console.WriteLine("Esercitazione 3 - .NET Cosnole");

            Console.WriteLine("I tipi di primitivi:");
            Console.WriteLine(@"I dati di tipo primitivo sono quei tipi di dato
            elementare che non possono essere scomposti in tipi più semplici.
            Rientrano in questa categoria i seguenti tipi di dato:
            - bool
            - byte, short, int, long
            - float, double, decimal
            - char
            - string");// in C no

            Console.WriteLine("I tipi derivati:");
            Console.WriteLine(@"I tipi di dato derivati sono quei tipi di dato
            non elementare che si creano componendo i tipi primitivi in diverse
            maniere.
            Rientrano in questa categoria i seguenti tipi di dato:
            - gli array (su qualsiasi dimensione) - tipi primitivi allocati
                in maniera omogenea
            - le struct - tipi primitivi allocati in maniera non omegenea
            - le classi - tipi primitivi allocati in maniera non omogenea, che seguono
                le regole della programmazone a oggetti
                (Object Oriented Programming - OOP)");

            Console.WriteLine("Gli array:");
            Console.WriteLine(@"Definiamo array una variabile che consiste nell'allocazione
            contigua di celle di memoria che contengono valori appartenenti allo stesso tipo
            primitivo.
            Tipicamente noi conosciamo gli array mono-dimensionali, e chiamiamo 'matrici'
            gli array multi-dimensionali");

            // inizializzazione diretta
            // con questa inizializzazione impostiamo
            // tutti i valori delle celle dell'array e 
            // sono quelle (non ne aggiungiamo altre vuote)
            //
            // int[] array = {}; // inizializzazione di un vettore vuoto
            int[] array = { 1, 2, 3, 4 };

            // inizializzazione array vuoto di dimensione 10
            // con questa inizializzazione impostiamo le 10 celle a
            // zero. Non ne aggiungiamo altre vuote
            int[] array2 = new int[10];

            // la dimensione non deve essere essere per forza definita come
            // costante: le variabili vanno anche bene.
            int n = 10;
            int[] array3 = new int[n];

            // il metodo Array.Resize ridimensiona un array mono-imensionale
            // dandogli una nuova dimensione
            //
            // se la nuova dimensione è maggiore della precedente, aggiunge nuove
            // celle impostando lo zero-value
            // 
            // se la nuova dimensione è minore della precedente, gli ultimi elementi
            // verranno eliminati per fare spazio
            // 
            // la parola chiave "ref" serve a passare per referenza (indirizzo / parola
            // con la p) la variabile.
            Array.Resize(ref array3, n * 2);

            Console.WriteLine(@"Per accedere a una cella di un array, usiamo la notaizone
            'a indice' (array[indice]). QUesto si può fare sia per la lettura che per 
            l'impostaizone / assegnamento");

            // imposto
            array[0] = 10;

            //leggo
            Console.WriteLine(array[0]);

            // l'indice può anche essere una variabile
            int x = 1;
            Console.WriteLine($"array[{x}] -> {array[x]}");

            // è possibile scorrere un array di qualsiasi tipo con uno o più cicli
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"array[{i}] -> {array[i]}");
            }

            Console.WriteLine(@"Definiamo matrice (a N dimensioni) un array
            multi-dimensionale avente esatamente N dimensioni.");

            // inizializzazione diretta
            int[,] matrix2D =
            {
                { 1, 2 },
                { 3, 4 },
            };

            // inizializzazione con zero-values
            int[,] matrix2DZero = new int[10, 10];

            // assegnamento  (notare come gli indici sono 2)
            matrix2DZero[0, 1] = 1;

            // lettura
            x = 1;
            int y = 1;
            Console.WriteLine($"matrix2DZero[{x}, {y}] -> {matrix2DZero[x, y]}");

            // inizializzazione diretta di una matrice a 3 dimensioni
            int[,,] matrix3D =
            {
                {
                    { 1, 2 },
                    { 3, 4 },
                },
                {
                    { 5, 6 },
                    { 7, 8 },
                },
            };

            // lettura
            int z = 0;
            Console.WriteLine($"matrix3D[{x}, {y}, {z}] ->  {matrix3D[x, y, z]}");

            Console.WriteLine("Nelle matrici, il .Length contiene il totale di celle");
            Console.WriteLine(@"Per ottenere gli elementi in una determinata dimensione,
                usiamo il metodo .GetLength(dimensione)");

            int rows = matrix2D.GetLength(0);
            int columns = matrix2D.GetLength(1);

            Console.WriteLine($"matrix2D ha {rows} righe e {columns} colonne");

            for (int i = 0;i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"matrix[{i}, {j}] -> {matrix2D[i, j]}");
                }
            }
        }
    }
}
