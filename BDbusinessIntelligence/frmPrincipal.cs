using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BDcreadorCSVoleDB
{
    public partial class frmPrincipal : Form
    {
        Random aleatorio;

        string[] nombres;
        string[] apellidos;
        List<string[]> automoviles;    // pos 0 : marca
        List<string[]> ciudadesZonas;  // pos 0 : estado
        string[] aseguradoras;

        string[] tablasNombres;
        string[] tablasDescripcion;

        public frmPrincipal()
        {
            InitializeComponent();
            aleatorio = new Random();
            nombres = new string[] { "Sofía", "Martina", "Daniela", "Valeria", "Noa", "Lucía", "María", "Emma", "Julia", "Paula", "Alba", "Carla", "Chloe", "Alma", "Valentina", "Mía", "Sara", "Carmen", "Claudia", "Elena", "Adriana", "Lola", "Alejandra", "Candela", "Vera", "Olivia", "Laia", "Ana", "Jimena", "Triana", "Laura", "Aitana", "Abril", "Irene", "Ariadna", "Marina", "Victoria", "Alicia", "Carlota", "Ainara", "Marta", "Clara", "Lara", "Inés", "Rocío", "Lía", "Manuela", "Andrea", "Ángela", "Blanca", "Ainhoa", "Nora", "Eva", "Natalia", "Elsa", "Nerea", "Aina", "Gala", "Naiara", "África", "Celia", "Arya", "Maia", "Paola", "Adara", "Alexia", "Aroa", "Carolina", "Iris", "Arlet", "Gabriela", "Mara", "Isabella", "Cayetana", "Indiana", "Julieta", "Mireia", "Elia", "Azahara", "Mar", "Noelia", "Isabel", "Nuria", "Luna", "Amaia", "Diana", "Nahia", "Aurora", "Berta", "Elisa", "Irati", "Cristina", "Nadia", "Camila", "Niños", "Hugo", "Lucas", "Martín", "Mateo", "Daniel", "Alejandro", "Pablo", "Eric", "Leo", "Adrián", "Álvaro", "Manuel", "Mario", "David", "Izan", "Álex", "Diego", "Dylan", "Oliver", "Marco", "Thiago", "Marcos", "Marc", "Sergio", "Javier", "Luca", "Gonzalo", "Carlos", "Nicolás", "Iván", "Antonio", "Ángel", "Bruno", "Miguel", "Héctor", "Gabriel", "Jorge", "Iker", "Gael", "Juan", "Rodrigo", "Jesús", "Samuel", "José", "Aarón", "Ian", "Rubén", "Julen", "Aitor", "Darío", "Liam", "Alan", "Paula", "Joel", "Alberto", "Pol", "Jaime", "Nil", "Francisco", "Luis", "Pedro", "Saúl", "Aleix", "Unai", "Biel", "Guillermo", "Santiago", "Víctor", "Alonso", "Rafael", "Víctor", "Noah", "Isaac", "Jan", "Martí", "Raúl", "Aimar", "Cristian", "Andrés", "Gerard", "Jordi", "Roberto", "Adam", "Derek", "Eloy", "Teo", "Abraham", "Ismael", "Kilian", "Noel", "Joan", "Romeo", "Yeray", "Miguel", "Ander", "Eduardo" };
            apellidos = new string[] { "Acosta", "Acuña", "Aguilar", "Aguirre", "Agustín", "Ahumada", "Alanis", "Alarcón", "Alayón", "Alcázar", "Alcocer", "Alfaro", "Almendárez", "Altamirano", "Álvarez", "Alzate", "Amador", "Anaya", "Argüelles", "Arjona", "Arriaga", "Arrollo", "Ayala", "Baca", "Báez", "Baños", "Barba", "Barrera", "Barrientos", "Barriga", "Bastida", "Batalla", "Bautista", "Bazán", "Becerra", "Becerril", "Bello", "Beltrán", "Benítez", "Bernal", "Bolaños", "Bonilla", "Borges", "Bustamante", "Busto", "Caballero", "Cabeza", "Cabrera", "Cadenas", "Caldera", "Calleja", "Calles", "Camacho", "Camareno", "Camarillo", "Campos", "Cárdenas", "Cardoso", "Carranza", "Carrillo", "Carvajal", "Carvallo", "Casas", "Castellanos", "Castañeda", "Cepeda", "Cerda", "Cervantes", "Céspedes", "Cevallos", "Cevedo", "Chávez", "Chavira", "Cisneros", "Collado", "Cordero", "Cornejo", "Correa", "Corro", "Cuéllar", "Cuervo", "Cuesta", "Cuevas", "Daniel", "Darío", "Dávila", "Aguilar", "Alba", "Cruz", "Cuesta", "Fuentes", "Rosas", "Castillo", "Doblado", "Domínguez", "Donato", "Dorado", "Duarte", "Dueñas", "Echeverría", "Elizondo", "Enríquez", "Escalante", "Escamilla", "Escobar", "Escobedo", "Escoto", "Espino", "Esquivel", "Estévez", "Estrada", "Estrella", "Fábregas", "Falcón", "Farías", "Fernández", "Ferreira", "Ferrer", "Fierro", "Figueras", "Flores", "Fonseca", "Fraga", "Frías", "Fuentes", "Funez", "Gaitán", "Galán", "Galeano", "Galeno", "Galindo", "Gallegos", "Galván", "Gamboa", "Gámez", "García", "Garrido", "Gavilán", "Gayoso", "Gaytán", "Gillén", "Godines", "Gómez", "Góngora", "Granada", "Granados", "Grijalba", "Guardado", "Guardiola", "Guerrero", "Guillén", "Gutiérrez", "Guzmán", "Heredia", "Hernández", "Herrera", "Hidalgo", "Hierro", "Huerta", "Hurtado", "Ibáñez", "Ibarra", "Icaza", "Iglesias", "Infante", "Izquierdo", "Jara", "Jaramillo", "Jerano", "Jiménez", "Juárez", "Junco", "Jurado", "Lacayo", "Lafuente", "Lagos", "Lagunal", "Lamas", "Lández", "Larios", "Lastreto", "Lázaro", "Leandro", "Lemus", "Leyva", "Linares", "Lines", "Lira", "Lizano", "Llano", "Lobo", "Lombardo", "López", "Loredo", "Lorio", "Losada", "Lozano", "Lucas", "Lugo", "Luna", "Macedo", "Machado", "Macías", "Maduro", "Magallón", "Maldonado", "Maltés", "Mantilla", "Manuel", "Manzanal", "Manzano", "Marcías", "Marrero", "Marroquí", "Martí", "Martínez", "Mateo", "Matías", "Maurer", "Medrano", "Medina", "Mendoza", "Mejía", "Mena", "Meneses", "Merazo", "Meza", "Mijares", "Milanés", "Minas", "Molina", "Molleda", "Moneda", "Monge", "Montalbán", "Montalvo", "Montecinos", "Montero", "Montes", "Montiel", "Morillo", "Moscoa", "Munera", "Murillo", "Naranjo", "Navaro", "Navarrete", "Navarro", "Nieto", "Noble", "Noguera", "Noriega", "Novales", "Novo", "Novoa", "Núñez", "Obellón", "Obregón", "Ocampo", "Ochoa", "Ordóñez", "Olguín", "Olivar", "Olivares", "Olivera", "Olmeda", "Olmedo", "Olmo", "Ordóñez", "Orozco", "Ortega", "Ortiz", "Oseda", "Osorio", "Ospino", "Otero", "Oviedo", "Ozuno", "Pacheco", "Padilla", "Páez", "Palacio", "Paladino", "Palazuelos", "Palomar", "Palomino", "Paniagua", "Pantoja", "Parado", "Páramo", "Pardo", "Paredes", "Parra", "Pastor", "Pastrana", "Patiño", "Paz", "Pedroza", "Pena", "Peña", "Peralta", "Peraza", "Perdomo", "Pineda", "Pino", "Plácido", "Ponce", "Portillo", "Prada", "Prieto", "Puente", "Quesada", "Quevedo", "Quijada", "Quijano", "Quintana", "Quintanilla", "Quiroga", "Quiroz", "Ramírez", "Ramón", "Ramos", "Rangel", "Real", "Redondo", "Restrepo", "Reyes", "Rivas", "Rivera", "Roble", "Robles", "Rojas", "Roldán", "Román", "Romero", "Rosales", "Rosas", "Rovira", "Rubín", "Rubio", "Rueda", "Ruiz", "Sabín", "Sáenz", "Sagel", "Salas", "Salazar", "Salcedo", "Saldaña", "Saldivar", "Salinas", "Salmón", "Salvado", "Samper", "Sánchez", "Sandino", "Sandoval", "Santiago", "Santos", "Sardinas", "Sarmiento", "Saucedo", "Savala", "Seballos", "Sedano", "Segura", "Silva", "Sol", "Solana", "Solé", "Soler", "Solís", "Somoza", "Sorio", "Sotelo", "Soto", "Sotomayor", "Soza", "Suárez", "Tablada", "Talavera", "Tames", "Taracena", "Tedesco", "Tejada", "Tobar", "Torre", "Torrente", "Tovar", "Travieso", "Trejos", "Treminio", "Triguero", "Troncoso", "Trujillo", "Ulloa", "Ureña", "Uriarte", "Uribe", "Urieta", "Urrutia", "Usaga", "Uveda", "Valdés", "Valdiva", "Valencia", "Valentín", "Valenzuela", "Vales", "Valle", "Vallejo", "Vanegas", "Varela", "Varga", "Vargas", "Vásquez", "Vega", "Vela", "Velarde", "Velasco", "Velásquez", "Venegas", "Ventura", "Verti", "Vidal", "Villallovos", "Villar", "Villareal", "Villas", "Villaseñor", "Villeda", "Vivas", "Vivero", "Vívez", "Zabaleta", "Zacarías", "Zaldívar", "Zambrano", "Zamora", "Zamudio", "Zapata", "Zarco", "Zavala", "Zavaleta", "Zelaya", "Zetina", "Zuleta", "Zúñiga" };

            automoviles = new List<string[]>();
            automoviles.Add(new string[] { "ASTON MARTIN", "DB9", "Vantage V8", "Vanquish", "Vantage V12", "Rapide" });
            automoviles.Add(new string[] { "AUDI", "A4", "A8", "A3", "TT", "A5", "A4 Allroad Quattro", "A6", "A7", "Q3", "Q5", "S5", "A1", "A6 Allroad Quattro", "S7", "S6", "S8", "RS4", "RS5", "R8", "SQ5", "Q7", "RS6", "RS7", "RS Q3", "S3", "S1", "TTS", "S4", "RS3", "SQ7", "Q2", "TTS", "SQ7", "S4", "S6", "S7" });
            automoviles.Add(new string[] { "BMW", "Serie 3", "Serie 5", "Serie 4", "Serie 7", "Z4", "X5", "Serie 1", "X3", "Serie 6", "X1", "X6", "I3", "Serie 2", "X4", "I8", "Serie 2 Gran Tourer", "Serie 2 Active Tourer", "X2", "BYD", "E6" });
            automoviles.Add(new string[] { "CHEVROLET", "Cruze", "Aveo", "Trax", "Orlando", "Spark", "Camaro" });
            automoviles.Add(new string[] { "FERRARI", "488", "GTC4", "California", "F12", "Portofino", "812", "458", "FF", "F12", "488" });
            automoviles.Add(new string[] { "FORD", "C-Max", "Fiesta", "Focus", "Mondeo", "Ka", "S-MAX", "B-MAX", "Grand C-Max", "Tourneo Custom", "Kuga", "Galaxy", "Grand Tourneo Connect", "Tourneo Connect", "EcoSport", "Tourneo Courier", "Mustang", "Transit Connect", "Edge", "Ka+" });
            automoviles.Add(new string[] { "HONDA", "Accord", "Jazz", "Civic", "CR-V", "HR-V" });
            automoviles.Add(new string[] { "HYUNDAI", "I20", "Ix35", "Ix20", "I10", "Santa Fe", "Veloster", "I40", "Elantra", "I30", "Grand Santa Fe", "Genesis", "H-1 Travel", "Tucson", "I20 Active", "IONIQ", "Kona" });
            automoviles.Add(new string[] { "INFINITI", "Q70", "Q50", "QX70", "QX50", "Q60", "Q30", "QX30", "ISUZU", "D-Max" });
            automoviles.Add(new string[] { "JEEP", "Grand Cherokee", "Wrangler Unlimited", "Cherokee", "Wrangler", "Renegade", "Compass", "Renegade" });
            automoviles.Add(new string[] { "KIA", "Picanto", "Rio", "Sportage", "Venga", "Optima", "Ceed", "Ceed Sportswagon", "Carens", "Pro_ceed", "Sorento", "Soul", "Niro", "Soul EV", "Pro_ceed GT", "Stonic", "Optima SW" });
            automoviles.Add(new string[] { "MAZDA", "Mazda2", "CX-5", "Mazda6", "MX-5", "Mazda3", "Mazda5", "CX-9", "CX-3" });
            automoviles.Add(new string[] { "MERCEDES", "Clase SL", "Clase SLK", "Clase V", "Clase C", "Clase M", "Clase G", "Clase E", "Clase CL", "Clase S", "Clase GLK", "SLS AMG", "Clase B", "Clase A", "Clase GL", "Clase CLS", "Clase CLA", "Clase GLA", "AMG GT", "Vito", "Clase GLE Coupé", "Clase GLE", "Clase GLE Coupé", "Clase GLK", "Clase GLC", "Citan", "Clase GLS", "Clase SLC", "GLC Coupé" });
            automoviles.Add(new string[] { "MITSUBISHI", "Montero", "I-MiEV", "ASX", "Outlander", "Space Star", "L200", "Eclipse Cross" });
            automoviles.Add(new string[] { "NISSAN", "X-TRAIL", "QASHQAI", "NOTE", "LEAF", "Pathfinder", "EVALIA", "Navara", "Micra", "JUKE", "370Z", "NV200", "GT-R" });
            automoviles.Add(new string[] { "PEUGEOT", "308", "807", "Bipper", "508", "Partner", "3008", "208", "2008", "RCZ", "5008", "4008", "108", "207", "Ion", "Traveller" });
            automoviles.Add(new string[] { "TOYOTA", "Avensis", "Land Cruiser", "Yaris", "Verso", "Auris", "Prius+", "GT86", "Prius", "Rav4", "Aygo", "Hilux", "Land Cruiser 200", "Proace Verso", "C-HR" });
            automoviles.Add(new string[] { "VOLKSWAGEN", "Polo", "Jetta", "Phaeton", "Golf", "Touran", "Touareg", "Beetle", "Sharan", "Tiguan", "Multivan", "California", "Caravelle", "Up!", "CC", "Golf Sportsvan", "Amarok", "Caddy", "Transporter", "Scirocco", "Passat", "Eos", "Arteon", "T-Roc", "Tiguan Allspace" });

            aseguradoras = new string[] { "Assurant Vida México", "Allianz México Compañía de Seguros", "General de Seguros", "Seguros Azteca Daños", "Ace Seguros", "Aseguradora Patrimonial Daños", "Tokio Marine Compañía de Seguros", "Patrimonial Inbursa", "Seguros Inbursa Grupo Financiero Inbursa", "Sompo Seguros México", "Mapfre México", "El Águila Compañía de Seguros", "Seguros Atlas", "Seguros Ve Por Más Grupo Financiero Ve Por Más", "AIG Seguros México", "Seguros Afirme Grupo Financiero Afirme", "Primero Seguros", "AXA Seguros", "Seguros Banorte Grupo Financiero Banorte", "Aseguradora Interacciones Grupo Financiero Interacciones", "Quálitas Compañía de Seguros", "Zurich Santander Seguros México", "Seguros BBVA Bancomer Grupo Financiero BBVA Bancomer", "Seguros Banamex Integrante del Grupo Financiero Banamex", "HDI Seguros", "ANA Compañía de Seguros", "La Latinoamericana Seguros" };

            ciudadesZonas = new List<string[]>();
            ciudadesZonas.Add(new string[] { "Aguascalientes", "Aguascalientes" });
            ciudadesZonas.Add(new string[] { "Baja California", "Ensenada", "Mexicali", "Tijuana", "Rosarito" });
            ciudadesZonas.Add(new string[] { "Baja California Sur", "Los Cabos", "Cabo San Lucas", "San José del Cabo", "Corredor Turístico", "Zona Pacífico Cabos", "La Paz", "Loreto" });
            ciudadesZonas.Add(new string[] { "Campeche", "Campeche", "Xpuhil", "Ciudad del Carmen" });
            ciudadesZonas.Add(new string[] { "Chiapas", "Chiapas", "San Cristóbal de las Casas", "Chiapa de Corzo", "Comitán", "Palenque", "Tapachula", "la Trinitaria", "Tuxtla Gutiérrez" });
            ciudadesZonas.Add(new string[] { "Chihuahua", "Chihuahua", "Ciudad Juárez", "Barrancas del Cobre", "Creel", "Delicias", "Posada Barrancas" });
            ciudadesZonas.Add(new string[] { "Coahuila", "Coahuila", "Torreón", "Saltillo", "Cuatro Ciénegas", "Arteaga", "Monclova", "Piedras Negras" });
            ciudadesZonas.Add(new string[] { "Colima", "Colima", "Manzanillo", "Isla Navidad" });
            ciudadesZonas.Add(new string[] { "Durango", "Durango" });
            ciudadesZonas.Add(new string[] { "Estado de México", "Atlacomulco", "Metepec", "Toluca", "Valle de Bravo", "Teotihuacan" });
            ciudadesZonas.Add(new string[] { "Ciudad de México", "Zona Aeropuerto", "Zona Condesa", "Zona Pedregal", "Centro Histórico", "Insurgentes Centro", "Insurgentes Norte", "Insurgentes Sur", "Insurgentes Viaducto", "Interlomas", "Zona Nápoles", "Perinorte", "Zona Polanco", "Zona Reforma", "Zona Santa Fe", "Zona Norte", "Zona Rosa" });
            ciudadesZonas.Add(new string[] { "Guanajuato", "Guanajuato", "Celaya", "Irapuato", "León", "San Miguel de Allende", "Silao" });
            ciudadesZonas.Add(new string[] { "Guerrero", "Acapulco", "Ixtapa", "Zihuatanejo", "Taxco", "Chilpancingo" });
            ciudadesZonas.Add(new string[] { "Hidalgo", "Pachuca", "Atotonilco", "Huejutla", "Tula", "Tulancingo" });
            ciudadesZonas.Add(new string[] { "Jalisco", "Guadalajara", "Tequila", "Tlaquepaque", "Zapopan", "Puerto Vallarta", "Boca de Tomatlán", "Marina Vallarta", "Mismaloya" });
            ciudadesZonas.Add(new string[] { "Michoacán", "Lázaro Cárdenas", "Morelia", "Pátzcuaro", "Tzintzuntzan", "Uruapan", "Zamora" });
            ciudadesZonas.Add(new string[] { "Morelos", "Cuautla", "Cuernavaca" });
            ciudadesZonas.Add(new string[] { "Nayarit", "la Riviera Nayarita", "Nuevo Vallarta", "Tepic" });
            ciudadesZonas.Add(new string[] { "Nuevo León", "Monterrey", "MTY Aeropuerto", "Monterrey Centro", "Monterrey Histórico", "Monterrey Cintermex", "Monterrey Galerías", "Monterrey Norte", "Monterrey Valle", "MTY Villa de Santiago" });
            ciudadesZonas.Add(new string[] { "Oaxaca", "Oaxaca", "Reforma y San Felipe", "Mitla", "Huatulco", "Puerto Escondido" });
            ciudadesZonas.Add(new string[] { "Puebla", "Cholula", "Cuautlancingo", "Jonotla" });
            ciudadesZonas.Add(new string[] { "Querétaro", "Santiago de Querétaro", "San Juan del Rio", "Jalpan de Serra", "Jurica", "Tequisquiapan" });
            ciudadesZonas.Add(new string[] { "Quintana Roo", "Cancún", "Cozumel", "Isla Holbox", "Isla Mujeres", "Majahual", "Chetumal", "Bacalar", "Playa del Carmen", "Puerto Aventuras", "Riviera Maya", "Akumal", "Kantenah", "Playa del Secreto", "Playa Paraiso", "Puerto Morelos", "Punta Bete", "Punta Maroma", "Tulum", "Xcalacoco", "Xcaret", "Xpuha" });
            ciudadesZonas.Add(new string[] { "San Luis Potosí", "San Luis Potosí", "Ciudad Valles" });
            ciudadesZonas.Add(new string[] { "Sinaloa", "Culiacán", "Los Mochis", "Mazatlán", "Mazatlán Centro", "Mazatlán Cerritos", "Mazatlán Malecón", "Mazatlán Zona Dorada" });
            ciudadesZonas.Add(new string[] { "Sonora", "Ciudad Obregón", "Guaymas San Carlos", "Hermosillo", "Nogales", "Puerto Peñasco" });
            ciudadesZonas.Add(new string[] { "Tabasco", "Villahermosa" });
            ciudadesZonas.Add(new string[] { "Tamaulipas", "Tampico", "Ciudad Madero", "Ciudad Victoria", "Matamoros", "Nuevo Laredo", "Reynosa" });
            ciudadesZonas.Add(new string[] { "Tlaxcala", "Tlaxcala", "Apizaco", "Huamantla" });
            ciudadesZonas.Add(new string[] { "Veracruz", "Boca del Rio", "Catemaco", "Jalcomulco", "Martínez de la Torre", "Minatitlán", "Orizaba", "Poza Rica", "Santiago Tuxtla", "Tuxpan", "El Puerto de Veracruz", "Jalapa", "Xico" });
            ciudadesZonas.Add(new string[] { "Yucatán", "Celestún", "Chichén Itzá", "Telchac Puerto", "Uxmal", "Valladolid", "Mérida" });
            ciudadesZonas.Add(new string[] { "Zacatecas", "Zacatecas" });

            tablasNombres = new string[] { "conductores", "ajustadores", "aseguradoras", "automoviles", "lugares", "choques" };

            /*

            tablas.Add(new Tabla("pilotos", "P", num * numPilotos, new string[] 
            { "idpiloto", "nombre", "rfc" }));
            tablas.Add(new Tabla("ajustadores", "J", num * numAjustadores, new string[] 
            { "idajustador", "nombre", "rfc", "idaseguradora" }));
            tablas.Add(new Tabla("aseguradoras", "S", num, new string[] 
            { "idaseguradora", "nombre" }));
            tablas.Add(new Tabla("lugares", "L", ciudadesZonas.Count, new string[] 
            { "idlugar", "zona", "estado" }));
            tablas.Add(new Tabla("automoviles", "A", num * numAutomoviles, new string[] 
            { "idautomovil", "modelo", "marca", "precio", "idaseguradora" }));
            tablas.Add(new Tabla("choques", "C", numChoques, new string[] 
            { "idchoque", "intensidad", "fecha", "idlugar", "idpilotox", "idautomovilx", "idajustadorx", "idpilotoy", "idautomovily", "idajustadory" }));

            */

            tablasDescripcion = new string[]
            {
                "CREATE TABLE pilotos ( " +
                        "[idpiloto] CHAR(6) NOT NULL PRIMARY KEY, " +
                        "[nombre] VARCHAR(100) NOT NULL, " +
                        "[rfc] CHAR(10) NOT NULL" +
                ")",
                "CREATE TABLE ajustadores ( " +
                        "[idajustador] CHAR(6) NOT NULL PRIMARY KEY, " +
                        "[nombre] VARCHAR(100) NOT NULL, " +
                        "[rfc] CHAR(10) NOT NULL, " +
                        "[idaseguradora] CHAR(6) NOT NULL" +
                ")",
                "CREATE TABLE aseguradoras ( " +
                        "[idaseguradora] CHAR(6) NOT NULL PRIMARY KEY, " +
                        "[nombre] VARCHAR(100) NOT NULL " +
                ")",
                "CREATE TABLE automoviles ( " +
                        "[idautomovil] CHAR(6) NOT NULL PRIMARY KEY, " +
                        "[modelo] VARCHAR(100) NOT NULL, " +
                        "[marca] VARCHAR(100) NOT NULL, " +
                        "[precio] DECIMAL(9,2) NOT NULL, " +
                        "[idaseguradora] CHAR(6) NOT NULL" +
                ")",
                "CREATE TABLE lugares ( " +
                        "[idlugar] CHAR(6) NOT NULL PRIMARY KEY, " +
                        "[zona] VARCHAR(100) NOT NULL, " +
                        "[estado] VARCHAR(100) NOT NULL" +
                ")",
                "CREATE TABLE choques ( " +
                        "[idchoque] CHAR(6) NOT NULL PRIMARY KEY, " +
                        "[intensidad] DECIMAL(3,2) NOT NULL, " +
                        "[fecha] DATE NOT NULL, " +
                        "[idlugar] CHAR(6) NOT NULL, " +
                        "[idpilotox] CHAR(6) NOT NULL, " +
                        "[idautomovilx] CHAR(6) NOT NULL, " +
                        "[idajustadorx] CHAR(6) NOT NULL, " +
                        "[idpilotoy] CHAR(6) NOT NULL, " +
                        "[idautomovily] CHAR(6) NOT NULL, " +
                        "[idajustadory] CHAR(6) NOT NULL" +
                ")"
            };
        }

        private void btBDverTABLA_Click(object sender, EventArgs e)
        {
            string tabla = cbBDtabla.Text;

            if (tabla != "(tabla)")
            {
                (new frmVisualizadorTabla(tabla)).Show();
            }
        }

        private void btBDcargar_Click(object sender, EventArgs e)
        {
            openFileDialogBD.Filter = "Archivos de MS Access (.mdb)|*.mdb";
            openFileDialogBD.FileName = "";
            openFileDialogBD.InitialDirectory = Application.StartupPath;
            openFileDialogBD.ShowDialog();
        }

        private void openFileDialogBD_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                string cadenaDeConexion = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data source = " + openFileDialogBD.FileName;
                OleDbConnection connection = new OleDbConnection(cadenaDeConexion);
                connection.Open();

                // Obtencion de informacion de base de datos: nombres de tablas
                var dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                var tableNames = (from DataRow row in dt.Rows let strSheetTableName = row["TABLE_NAME"].ToString() where row["TABLE_TYPE"].ToString() == "TABLE" select row["TABLE_NAME"].ToString()).ToList();

                Comun.baseDatos = new DataSet();
                cbBDtabla.Items.Clear();

                foreach (var tableName in tableNames)
                {
                    string queryString = "SELECT * FROM " + tableName;
                    OleDbDataAdapter adapter = new OleDbDataAdapter(queryString, connection);
                    adapter.Fill(Comun.baseDatos, tableName);
                    cbBDtabla.Items.Add(tableName);
                }

                connection.Close();

                if (cbBDtabla.Items.Count > 0)
                {
                    cbBDtabla.SelectedIndex = 0;
                }

                MessageBox.Show("La base de datos ha sido cargada con exito");

                btBDverTABLA.Enabled = true;
                btVerAnalisis.Enabled = true;
                btBDguardar.Enabled = true;
            }
            catch
            {
                MessageBox.Show("La base de datos elegida no sigue el formato esperado.\n\nGenérela por medio de este programa para garantizar su funcionalidad.");
            }

        }

        private void btBDguardar_Click(object sender, EventArgs e)
        {
            saveFileDialogBD.Filter = "Archivos de MS Access (.mdb)|*.mdb";
            saveFileDialogBD.FileName = "BD_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            saveFileDialogBD.InitialDirectory = Application.StartupPath;
            saveFileDialogBD.DefaultExt = ".mdb";
            saveFileDialogBD.ShowDialog();
        }

        private void saveFileDialogBD_FileOk(object sender, CancelEventArgs e)
        {

            if (DialogResult.Yes == MessageBox.Show("Los datos se pueden guardar todos como Text (varchar (255)) o indicando su tipo para date y decimal.\n\nEl tipo genérico de texto se importa fácilmente y es el sugerido.\n\nSi elige sí será en tipo text, si elige no será distinguiendo fechas y números.", "Tipos de datos a guardar", MessageBoxButtons.YesNo))
            {
                using (new IndicadorEspera(this.Location))
                {
                    GuardadoTextoOledb(saveFileDialogBD.FileName);
                }
            }
            else
            {
                using (new IndicadorEspera(this.Location))
                {
                    GuardadoDetalladoOleDB(saveFileDialogBD.FileName);
                }
            }
            //GuardadoDetalladoOleDB(saveFileDialogBD.FileName);
            //GuardadoTextoOledb(saveFileDialogBD.FileName);
        }

        private void GuardadoDetalladoOleDB(string archivo)
        {
            try
            {
                // Guardado especial para la base de datos creado con indicacion de tipo de dato en campos
                System.IO.File.WriteAllBytes(archivo, Properties.Resources.BDvaciaACCESS2002);
                string cadenaDeConexion = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data source = " + archivo;
                OleDbConnection conexion = new OleDbConnection(cadenaDeConexion);

                // Creacion de tablas y campos específicos
                conexion.Open();
                for (int i = 0; i < tablasDescripcion.Length; i++)
                {
                    OleDbCommand comando = new OleDbCommand(tablasDescripcion[i], conexion);
                    comando.ExecuteNonQuery();
                }

                // Obtencion de nombres de tablas leyendo archivo con tablas y sin registros
                DataTable dt = conexion.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                List<string> tablaNombres = (from DataRow row in dt.Rows let strSheetTableName = row["TABLE_NAME"].ToString() where row["TABLE_TYPE"].ToString() == "TABLE" select row["TABLE_NAME"].ToString()).ToList();

                foreach (string tabNombre in tablaNombres)
                {
                    foreach (DataRow registro in Comun.baseDatos.Tables[tabNombre].Rows)
                    {
                        string campos = "";
                        foreach (DataColumn campo in Comun.baseDatos.Tables[tabNombre].Columns)
                        {
                            // Quita apostrofes
                            //campos += " '" + registro[campo.ColumnName].ToString().Replace('\'', ' ') + "',";
                            if (campo.ColumnName == "intensidad" || campo.ColumnName == "precio")
                            {
                                campos += " " + registro[campo.ColumnName].ToString() + ",";
                            }
                            else
                            {
                                campos += " '" + registro[campo.ColumnName].ToString() + "',";
                            }
                        }
                        campos = campos.Substring(0, campos.Length - 1);    // quita la ultima coma

                        string sql = "INSERT INTO " + tabNombre + " VALUES(" + campos + ")";
                        OleDbCommand comando = new OleDbCommand(sql, conexion);
                        comando.ExecuteNonQuery();
                    }
                }
                conexion.Close();
                MessageBox.Show("Base de Datos con tipo de Dato especifico guardada con éxito.\n\n" + archivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GuardadoTextoOledb(string archivo)
        {
            try
            {
                // Guardado general según dataset
                System.IO.File.WriteAllBytes(archivo, Properties.Resources.BDvaciaACCESS2002);
                string cc = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data source = " + archivo;
                OleDbConnection cn = new OleDbConnection(cc);

                foreach (DataTable tabla in Comun.baseDatos.Tables)
                {
                    string campos = "";

                    foreach (DataColumn campo in tabla.Columns)
                    {
                        campos += " [" + campo.ColumnName + "] Text,";    // Todos tipo text[255]
                    }
                    campos = campos.Substring(0, campos.Length - 1);    // quita la ultima coma

                    cn.Open();
                    string sql = "CREATE TABLE [" + tabla.TableName + "](" + campos + ")"; //string.Format("INSERT INTO CMI (tabla, objetivo) values('{0}', '{1}')", encabezados[k], dgv[k][1, i].Value);
                    OleDbCommand comando = new OleDbCommand(sql, cn);
                    comando.ExecuteNonQuery();

                    foreach (DataRow registro in tabla.Rows)
                    {
                        campos = "";
                        foreach (DataColumn campo in tabla.Columns)
                        {
                            // Quita apostrofes
                            //campos += " '" + registro[campo.ColumnName].ToString().Replace('\'', ' ') + "',";

                            campos += " '" + registro[campo.ColumnName].ToString() + "',";
                        }
                        campos = campos.Substring(0, campos.Length - 1);    // quita la ultima coma

                        sql = "INSERT INTO " + tabla.TableName + " VALUES(" + campos + ")";
                        comando = new OleDbCommand(sql, cn);
                        comando.ExecuteNonQuery();
                    }
                    cn.Close();
                }
                MessageBox.Show("Guardado exitoso con campos tipo text o varchar(255) de la base de datos.\n\n" + archivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string RFC(string nombreDado)
        {
            string[] palabras = nombreDado.Split(' ');
            string rfc = palabras[1].Substring(0, 2) + palabras[2].Substring(0, 1) + palabras[0].Substring(0, 1) + aleatorio.Next(60, 100) + "0" + aleatorio.Next(1, 10) + aleatorio.Next(10, 28);

            string v = palabras[1].Substring(1);

            v = v.Replace('a', 'A');
            v = v.Replace('e', 'E');
            v = v.Replace('i', 'I');
            v = v.Replace('o', 'O');
            v = v.Replace('u', 'U');

            v = v.Replace('á', 'A');
            v = v.Replace('é', 'E');
            v = v.Replace('í', 'I');
            v = v.Replace('ó', 'O');
            v = v.Replace('ú', 'U');

            v = v.Replace('Á', 'A');
            v = v.Replace('É', 'E');
            v = v.Replace('Í', 'I');
            v = v.Replace('Ó', 'O');
            v = v.Replace('Ú', 'U');

            v = v.Replace('ä', 'A');
            v = v.Replace('ë', 'E');
            v = v.Replace('ï', 'I');
            v = v.Replace('ö', 'O');
            v = v.Replace('ü', 'U');

            bool vocalEncontrada = false;
            int i;
            for (i = 0; i < v.Length; i++)
            {
                switch (v[i])
                {
                    case 'A':
                    case 'E':
                    case 'I':
                    case 'O':
                    case 'U':
                        vocalEncontrada = true;
                        break;
                }
                if (vocalEncontrada)
                {
                    break;
                }
            }

            if (vocalEncontrada)
            {
                rfc = rfc.Substring(0, 1) + v[i].ToString() + rfc.Substring(2);
            }
            else
            {
                rfc = rfc.Substring(0, 1) + "X" + rfc.Substring(2);
                //MessageBox.Show(rfc);
            }

            rfc = rfc.Replace('Á', 'A');
            rfc = rfc.Replace('É', 'E');
            rfc = rfc.Replace('Í', 'I');
            rfc = rfc.Replace('Ó', 'O');
            rfc = rfc.Replace('Ú', 'U');

            rfc = rfc.Replace('Ä', 'A');
            rfc = rfc.Replace('Ë', 'E');
            rfc = rfc.Replace('Ï', 'I');
            rfc = rfc.Replace('Ö', 'O');
            rfc = rfc.Replace('Ü', 'U');

            if (rfc.Substring(0, 1) == "Ñ")
            {
                rfc = "X" + rfc.Substring(1);
                //MessageBox.Show(rfc);
            }

            return rfc;
            //return palabras[1].Substring(0, 2) + palabras[2].Substring(0, 1) + palabras[0].Substring(0, 1) + aleatorio.Next(60, 100) + "0" + aleatorio.Next(1, 10) + aleatorio.Next(10, 28);
        }

        private void btBDcrear_Click(object sender, EventArgs e)
        {
            int numAjustadores = Convert.ToInt32(tbNumAjustadores.Text);
            int numAutomoviles = Convert.ToInt32(tbNumAutomoviles.Text);
            int numPilotos = Convert.ToInt32(tbNumPilotos.Text);
            int numChoques = Convert.ToInt32(tbNumChoques.Text);

            Comun.baseDatos = new DataSet();
            cbBDtabla.Items.Clear();
            cbBDtabla.Text = "(tabla)";

            int num = aseguradoras.Length;

            List<Tabla> tablas = new List<Tabla>();
            tablas.Add(new Tabla("lugares", "L", ciudadesZonas.Count, new string[] { "idlugar", "zona", "estado" }));
            tablas.Add(new Tabla("aseguradoras", "S", num, new string[] { "idaseguradora", "nombre" }));
            tablas.Add(new Tabla("ajustadores", "J", num * numAjustadores, new string[] { "idajustador", "nombre", "rfc", "idaseguradora" }));
            tablas.Add(new Tabla("pilotos", "P", num * numPilotos, new string[] { "idpiloto", "nombre", "rfc" }));
            tablas.Add(new Tabla("automoviles", "A", num * numAutomoviles, new string[] { "idautomovil", "modelo", "marca", "precio", "idaseguradora" }));
            tablas.Add(new Tabla("choques", "C", numChoques, new string[] { "idchoque", "intensidad", "fecha", "idlugar", "idpilotox", "idautomovilx", "idajustadorx", "idpilotoy", "idautomovily", "idajustadory" }));

            // ===================================================    Creacion tablas y campos
            for (int k = 0; k < tablas.Count; k++)
            {
                Comun.baseDatos.Tables.Add(tablas[k].nombre);
                for (int i = 0; i < tablas[k].campos.Length; i++)
                {
                    Comun.baseDatos.Tables[tablas[k].nombre].Columns.Add(tablas[k].campos[i]);
                }
                cbBDtabla.Items.Add(tablas[k].nombre);
            }
            cbBDtabla.SelectedIndex = cbBDtabla.Items.Count - 1;

            // ===================================================    0 Lugares
            int contador = 0;
            for (int i = 0; i < ciudadesZonas.Count; i++)
            {
                for (int k = 1; k < ciudadesZonas[i].Length; k++)
                {
                    Comun.baseDatos.Tables[tablas[0].nombre].Rows.Add(tablas[0].idletra + (100001 + contador).ToString().Substring(1), ciudadesZonas[i][k], ciudadesZonas[i][0]);
                    contador++;
                }                    
            }
            tablas[0].cantidad = contador;

            // ===================================================    1 Aseguradoras
            for (int i = 0; i < aseguradoras.Length; i++)
            {
                Comun.baseDatos.Tables[tablas[1].nombre].Rows.Add(tablas[1].idletra + (100001 + i).ToString().Substring(1), aseguradoras[i]);
            }

            // ===================================================    2 Ajustadores
            contador = 0;
            string nombre = "";
            for (int i = 0; i < aseguradoras.Length; i++)
            {
                // Ajustadores por aseguradora
                for(int k = 0; k < numAjustadores; k++)
                {
                    nombre = nombres[aleatorio.Next(0, nombres.Length)] + " " + apellidos[aleatorio.Next(0, apellidos.Length)] + " " + apellidos[aleatorio.Next(0, apellidos.Length)];
                    Comun.baseDatos.Tables[tablas[2].nombre].Rows.Add(tablas[2].idletra + (100001 + contador).ToString().Substring(1), nombre, RFC(nombre), tablas[1].idletra + (100001 + i).ToString().Substring(1));
                    contador++;
                }
            }
            tablas[2].cantidad = contador;

            // ===================================================    3 Pilotos
            contador = 0;
            nombre = "";
            for (int i = 0; i < aseguradoras.Length; i++)
            {
                // Pilotos por aseguradora
                for (int k = 0; k < numPilotos; k++)
                {
                    nombre = nombres[aleatorio.Next(0, nombres.Length)] + " " + apellidos[aleatorio.Next(0, apellidos.Length)] + " " + apellidos[aleatorio.Next(0, apellidos.Length)];
                    Comun.baseDatos.Tables[tablas[3].nombre].Rows.Add(tablas[3].idletra + (100001 + contador).ToString().Substring(1), nombre, RFC(nombre));
                    contador++;
                }
            }
            tablas[3].cantidad = contador;

            // ===================================================    4 Automoviles
            contador = 0;
            for (int i = 0; i < aseguradoras.Length; i++)
            {
                // Automoviles por aseguradora
                for (int k = 0; k < numAutomoviles; k++)
                {
                    int numMarca = aleatorio.Next(0, automoviles.Count);
                    Comun.baseDatos.Tables[tablas[4].nombre].Rows.Add(tablas[4].idletra + (100001 + contador).ToString().Substring(1),
                        automoviles[numMarca][aleatorio.Next(1, automoviles[numMarca].Length)],
                        automoviles[numMarca][0],
                        aleatorio.Next(45000,700001),
                        tablas[1].idletra + (100001 + i).ToString().Substring(1)
                    );
                    contador++;
                }
            }
            tablas[4].cantidad = contador;

            // ===================================================    5 Choques
            contador = 0;
            DateTime fecha = new DateTime(dtpFechaInicial.Value.Year, dtpFechaInicial.Value.Month, dtpFechaInicial.Value.Day);
            int maxChoquesPorDia = Convert.ToInt32(tbMaxChoquesPorDia.Text);
            int maxDiasSinChoque = Convert.ToInt32(tbMaxDiasSinChoque.Text) + 1;

            for (int i = 0; contador < numChoques; i++)
            {
                fecha = fecha.AddDays(aleatorio.Next(1, maxDiasSinChoque));

                // Choques en ese dia
                int choquesEseDia = aleatorio.Next(0, maxChoquesPorDia);

                if (numChoques - contador < choquesEseDia)
                {
                    choquesEseDia = numChoques - contador;
                }

                for (int k = 0; k < choquesEseDia ; k++)
                {
                    int numPilotoA = aleatorio.Next(0, tablas[3].cantidad);
                    int numPilotoB = aleatorio.Next(0, tablas[3].cantidad);
                    while (numPilotoA == numPilotoB)
                    {
                        numPilotoB = aleatorio.Next(0, tablas[3].cantidad);
                    }
                    int numAutomovilA = aleatorio.Next(0, tablas[4].cantidad);
                    int numAutomovilB = aleatorio.Next(0, tablas[4].cantidad);
                    while (numAutomovilA == numAutomovilB)
                    {
                        numAutomovilB = aleatorio.Next(0, tablas[4].cantidad);
                    }
                    nombre = nombres[aleatorio.Next(0, nombres.Length)] + " " + apellidos[aleatorio.Next(0, apellidos.Length)] + " " + apellidos[aleatorio.Next(0, apellidos.Length)];
                    Comun.baseDatos.Tables[tablas[5].nombre].Rows.Add(tablas[5].idletra + (100001 + contador).ToString().Substring(1),
                        aleatorio.Next(1, 99) / 100.0,
                        fecha.ToString("yyyy-MM-dd"),
                        tablas[0].idletra + (100001 + aleatorio.Next(0, tablas[0].cantidad)).ToString().Substring(1),
                        tablas[3].idletra + (100001 + numPilotoA).ToString().Substring(1),
                        tablas[4].idletra + (100001 + numAutomovilA).ToString().Substring(1),
                        tablas[2].idletra + (100001 + (numAutomovilA / numAutomoviles) * numAjustadores + aleatorio.Next(0, numAjustadores) ).ToString().Substring(1),
                        tablas[3].idletra + (100001 + numPilotoB).ToString().Substring(1),
                        tablas[4].idletra + (100001 + numAutomovilB).ToString().Substring(1),
                        tablas[2].idletra + (100001 + (numAutomovilB / numAutomoviles) * numAjustadores + aleatorio.Next(0, numAjustadores)).ToString().Substring(1)
                    );
                    contador++;
                }
            }
            tablas[5].cantidad = contador;

            btBDverTABLA.Enabled = true;
            btVerAnalisis.Enabled = true;
            btBDguardar.Enabled = true;
        }

        private void btVerAnalisis_Click(object sender, EventArgs e)
        {
            try
            {
                (new frmAnalisis()).Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
    }

    public class Tabla
    {
        public string nombre;
        public string idletra;
        public int cantidad;
        public string[] campos;

        public Tabla(string nombre1, string idletra1, int cantidad1, string[] campos1)
        {
            nombre = nombre1;
            idletra = idletra1;
            cantidad = cantidad1;
            campos = campos1;
        }
    }
}
