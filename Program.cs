using System;

namespace A889343.Actividad02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] productos_ar = new string[100, 2];
            int comando = 0; 
            int contador = 0;
            
            Console.WriteLine("Por favor, indique el ID del producto a ingresar: 0, 1, 2, 3 o 4." +
                    "\n Seleccione 5 si desea salir");
            comando = Int16.Parse(Console.ReadLine());
            while (comando != 5)
            {
                if (comando >= 0)
                {
                    string sumador = agregarProducto();
                    string[] line = sumador.Split("//");
                    productos_ar[contador, 0] = line[0];
                    productos_ar[contador, 1] = line[1];
                    contador++;

                    Console.WriteLine("Su stock actual es: ");
                    mostrarLista(productos_ar, contador);

                    Console.WriteLine("Ingrese el ID del producto por el que quiere registrar un Pedido o Entrega: ");
                    string producto_nro = Console.ReadLine();

                    Console.WriteLine("Ingrese P si es un Pedido o E si es entrega: ");
                    string producto_tipo = Console.ReadLine();

                    Console.WriteLine("Ingrese la cantidad a registrar: ");
                    int cant = Int16.Parse(Console.ReadLine());
                    
                    if (cant > 0)
                    {
                        if (producto_tipo.Equals("P"))
                        {
                            int prd = buscarProducto(producto_nro, productos_ar, contador);
                            if (prd > -1)
                            {
                                productos_ar = actualizarProducto(prd, true, cant, productos_ar);
                                mostrarLista(productos_ar, contador);
                            }
                        }
                        else if (producto_tipo.Equals("E"))
                        {
                            int prd = buscarProducto(producto_nro, productos_ar, contador);
                            if (prd > -1)
                            {
                                productos_ar = actualizarProducto(prd, false, cant, productos_ar);
                                mostrarLista(productos_ar, contador);
                            }
                        }
                        else
                        {
                            Console.WriteLine("El ingreso que intenta realizar, no es válido.");
                        }
                    }


                }
            }



        }

        static string agregarProducto()
        {
            Console.WriteLine("Por favor, ingresa el ID del producto.");
            string producto_nro = Console.ReadLine();

            Console.WriteLine("El ID del producto es: " + producto_nro);

            Console.WriteLine("Ingrese la cantidad: ");
            int producto_cant = Int16.Parse(Console.ReadLine());

            Console.WriteLine("Se ingresó para el producto ID " + producto_nro + " , la cantidad de: " + producto_cant + " unidades.");
            return producto_nro + "//" + producto_cant;
        }

        static void mostrarLista(string[,] listado, int cantidad)
        {
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine("Producto ID: " + listado[i, 0] + " - Cantidad: " + listado[i, 1]);
            }
        }

        static int buscarProducto(string nro, string[,] listado, int cantidad)
        {
            int contador = 0;
            while (contador < cantidad)
            {
                if (listado[contador, 0].Equals(nro))
                {
                    return contador;
                }
                contador++;
            }
            return -1;
        }

        static string[,] actualizarProducto(int prd, Boolean espedido, int cantidad, string[,] listado)
        {
            int cantidadInicial = Int16.Parse(listado[prd, 1]);
            if (espedido)
            {
                if (cantidadInicial - cantidad >= 0)
                {
                    int total = cantidadInicial - cantidad;
                    listado[prd, 1] = total.ToString();
                    return listado;
                }
                else
                {
                    Console.WriteLine("Error, el stock actual es menor a cero.");
                    return listado;
                }
            }
            else
            {
                int total = cantidadInicial + cantidad;
                listado[prd, 1] = total.ToString();
                return listado;
            }
        }
    }
}


