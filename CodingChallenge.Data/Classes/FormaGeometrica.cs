/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometrica 
    {
        #region Formas

        //public const int Cuadrado = 1;
        //public const int TrianguloEquilatero = 2;
        //public const int Circulo = 3;
        //public const int Trapecio = 4;

        #endregion

        #region Idiomas

        //public const int Castellano = 1;
        //public const int Ingles = 2;

        #endregion



        private readonly decimal _lado;
        private readonly decimal _bmenor;
        private readonly decimal _altura;

        public int Tipo { get; set; }

        public FormaGeometrica(int tipo, decimal ancho, decimal bmenor, decimal altura)
        {
            Tipo = tipo;
            _lado = ancho;
            _bmenor = bmenor;
            _altura = altura;
        }

        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                if (idioma == Castellano)
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                elseIf(idioma == Ingles)
                    sb.Append("<h1>Empty list of shapes!</h1>");
                elseIf(idioma == Portugues)
                    sb.Append("<h1>Lista vazia de formas!</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                if (idioma == Castellano)
                    sb.Append("<h1>Reporte de Formas</h1>");
                elseIf(idioma == Ingles)
                    // default es inglés
                    sb.Append("<h1>Shapes report</h1>");
                elseIf(idioma == Portugues)
                    sb.Append("<h1>Relatório de Formulário!</h1>");

                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;
                var numeroTrapecios = 0;
                var numeroRectangulos = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;
                var areaTrapecios = 0m;
                var areaRectangulos = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;
                var perimetroTrapecios = 0m;
                var perimetroRectangulos = 0m;

                string pPerimetroTitle = "";
                string pFormaTitle = "''";

                for (var i = 0; i < formas.Count; i++)
                {
                    if (formas[i].Tipo == Cuadrado)
                    {
                        numeroCuadrados++;
                        areaCuadrados += formas[i].CalcularArea();
                        perimetroCuadrados += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == Circulo)
                    {
                        numeroCirculos++;
                        areaCirculos += formas[i].CalcularArea();
                        perimetroCirculos += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == TrianguloEquilatero)
                    {
                        numeroTriangulos++;
                        areaTriangulos += formas[i].CalcularArea();
                        perimetroTriangulos += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == Trapecio)
                    {
                        numeroTrapecio++;
                        areaTrapecio += formas[i].CalcularArea();
                        perimetroTrapecio += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == Rectangulo)
                    {
                        numeroRectangulo++;
                        areaRectangulo += formas[i].CalcularArea();
                        perimetroRectangulo += formas[i].CalcularPerimetro();
                    }
                }
                
                sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, Cuadrado, idioma));
                sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, Circulo, idioma));
                sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, TrianguloEquilatero, idioma));

                if (idioma == Castellano)
                {
                    pPerimetroTitle = "Perimetro ";
                }elseif(idioma == Ingles){
                    pPerimetroTitle = "Perimeter ";                        
                }elseif(idioma == Portugues){
                    pPerimetroTitle = "Perímetro "; 
                }

                
                if (idioma == Castellano)
                {
                    pFormaTitle = "formas ";
                }elseif(idioma == Ingles){
                    pFormaTitle = "shapes ";                        
                }elseif(idioma == Portugues){
                    pFormaTitle = "formas "; 
                }

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + pFormaTitle + " ");
                sb.Append(pPerimetroTitle + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##") + " ");
                sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##"));
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            if (cantidad > 0)
            {
                if (idioma == Castellano)
                    return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";

                if (idioma == Portugues)
                    return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perímetro {perimetro:#.##} <br/>";

                return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        private static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            switch (tipo)
            {
                case Cuadrado:
                    if (idioma == Castellano) {return cantidad == 1 ? "Cuadrado" : "Cuadrados"};
                    elseif(idioma == Ingles) {return cantidad == 1 ? "Square" : "Squares"};
                    elseif(idioma == Portugues) {return cantidad == 1 ? "Quadrado" : "quadrados"};
                case Circulo:
                    if (idioma == Castellano) {return cantidad == 1 ? "Círculo" : "Círculos"};
                    elseif(idioma == Ingles) {return cantidad == 1 ? "Circle" : "Circles"};
                    elseif(idioma == Portugues) {return cantidad == 1 ? "Círculo" : "Círculos"};
                case TrianguloEquilatero:
                    if (idioma == Castellano) {return cantidad == 1 ? "Triángulo" : "Triángulos"};
                    elseif(idioma == Ingles) {return cantidad == 1 ? "Triangle" : "Triangles"};
                    elseif(idioma == Portugues) {return cantidad == 1 ? "Triângulo" : "Triângulos"};
                case Trapecio:
                    if (idioma == Castellano) {return cantidad == 1 ? "Trapecio" : "Trapecios"};
                    elseif(idioma == Ingles) {return cantidad == 1 ? "Trapeze" : "Trapezoids"};
                    elseif(idioma == Portugues) {return cantidad == 1 ? "Trapézio" : "Trapézios"};
                case Rectangulo:
                    if (idioma == Castellano) {return cantidad == 1 ? "Rectangulo" : "Rectangulos"};
                    elseif(idioma == Ingles) {return cantidad == 1 ? "Rectangle" : "Rectangles"};   
                    elseif(idioma == Portugues) {return cantidad == 1 ? "Rectangulo" : "Rectangulos"};                                        
            }

            return string.Empty;
        }

        public decimal CalcularArea()
        {
            switch (Tipo)
            {
                case Cuadrado: return _lado * _lado;
                case Circulo: return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
                case TrianguloEquilatero: return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
                case Trapecio: return  ((_lado + _bmenor) / 2)*_altura;
                case Rectangulo: return 2*_lado + 2*_lado;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        public decimal CalcularPerimetro()
        {
            switch (Tipo)
            {
                case Cuadrado: return _lado * 4;
                case Circulo: return (decimal)Math.PI * _lado;
                case TrianguloEquilatero: return _lado * 3;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }
    }
}
