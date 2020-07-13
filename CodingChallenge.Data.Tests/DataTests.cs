using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 2));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            FormaIdioma pFormaGeom = new FormaIdioma();
            pFormaGeom.Cuadrado = 1;

            FormaIdioma pIdioma = new FormaIdioma();
            pIdioma.Castellano = 1;

            var cuadrados = new List<FormaGeometrica> {new FormaGeometrica(pFormaGeom.Cuadrado, 5, 0, 0)};

            var resumen = FormaGeometrica.Imprimir(cuadrados, pIdioma.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConTrapecioRectanguloPortugues()
        {
            FormaIdioma pFormaGeom = new FormaIdioma();
            pFormaGeom.Trapecio = 4;
            pFormaGeom.Rectangulo = 5;

            FormaIdioma pIdioma = new FormaIdioma();
            pIdioma.Portugues = 3;
            
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(pFormaGeom.Trapecio, 5, 4, 3),
                new FormaGeometrica(pFormaGeom.Rectangulo, 3, 0, 0),
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, pIdioma.Portugues);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }
        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            FormaIdioma pFormaGeom = new FormaIdioma();
            pFormaGeom.Cuadrado = 1;

            FormaIdioma pIdioma = new FormaIdioma();
            pIdioma.Ingles = 2;
            var cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica(pFormaGeom.Cuadrado, 5, 0, 0),
                new FormaGeometrica(pFormaGeom.Cuadrado, 1, 0, 0),
                new FormaGeometrica(pFormaGeom.Cuadrado, 3, 0, 0)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, pIdioma.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            FormaIdioma pFormaGeom = new FormaIdioma();
            pFormaGeom.Cuadrado = 1;
            pFormaGeom.Circulo = 3;
            pFormaGeom.TrianguloEquilatero = 2;  

            FormaIdioma pIdioma = new FormaIdioma();
            pIdioma.Ingles = 2;
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(pFormaGeom.Cuadrado, 5, 0, 0),
                new FormaGeometrica(pFormaGeom.Circulo, 3, 0, 0),
                new FormaGeometrica(pFormaGeom.TrianguloEquilatero, 4, 0, 0),
                new FormaGeometrica(pFormaGeom.Cuadrado, 2, 0, 0),
                new FormaGeometrica(pFormaGeom.TrianguloEquilatero, 9, 0, 0),
                new FormaGeometrica(pFormaGeom.Circulo, 2.75m, 0, 0,
                new FormaGeometrica(pFormaGeom.TrianguloEquilatero, 4.2m, 0, 0)
            };

            var resumen = FormaGeometrica.Imprimir(formas, pIdioma.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            FormaIdioma pFormaGeom = new FormaIdioma();
            pFormaGeom.Cuadrado = 1;
            pFormaGeom.Circulo = 3;
            pFormaGeom.TrianguloEquilatero = 2; 

            FormaIdioma pIdioma = new FormaIdioma();
            pIdioma.Castellano = 1;
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(FormaGeometrica.Cuadrado, 5, 0, 0),
                new FormaGeometrica(FormaGeometrica.Circulo, 3, 0, 0),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4, 0, 0),
                new FormaGeometrica(FormaGeometrica.Cuadrado, 2, 0, 0),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 9, 0, 0),
                new FormaGeometrica(FormaGeometrica.Circulo, 2.75m, 0, 0),
                new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4.2m, 0, 0)
            };

            var resumen = FormaGeometrica.Imprimir(formas, pIdioma.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }
    }
}
