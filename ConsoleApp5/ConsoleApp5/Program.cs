using System;
using System.Collections.Generic;

// Enumeración que define los tipos de vehículos
public enum TipoVehiculo
{
    Automovil,
    Motocicleta,
    Camion,
    Bicicleta
}

// Enumeración que define los tipos de combustible
public enum TipoCombustible
{
    Gasolina,
    Diesel,
    Electrico,
    Hibrido,
    NoAplica
}

// Interfaz que define comportamientos comunes para vehículos
public interface IVehiculo
{
    string Marca { get; set; }
    string Modelo { get; set; }
    int Año { get; }
    TipoVehiculo Tipo { get; }

    void Arrancar();
    void Detener();
    string ObtenerInformacion();
}

// Interfaz para vehículos motorizados
public interface IMotorizado
{
    TipoCombustible Combustible { get; set; }
    double CapacidadTanque { get; set; }
    void Reabastecer(double cantidad);
}


// Clase base abstracta que implementa la interfaz IVehiculo
public abstract class VehiculoBase : IVehiculo
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Año { get; }
    public abstract TipoVehiculo Tipo { get; }

    // Constructor con init en lugar de set
    protected VehiculoBase(string marca, string modelo, int año)
    {
        Marca = marca;
        Modelo = modelo;
        Año = año;
    }

    public virtual void Arrancar() => Console.WriteLine($"El vehículo {Marca} {Modelo} está arrancando.");

    public virtual void Detener() => Console.WriteLine($"El vehículo {Marca} {Modelo} se ha detenido.");

    public abstract string ObtenerInformacion();
}

// Clase concreta que hereda de VehiculoBase e implementa IMotorizado
public class Automovil : VehiculoBase, IMotorizado
{
    public TipoCombustible Combustible { get; set; }
    public double CapacidadTanque { get; set; } = 50.0; // Valor por defecto
    public int NumeroPuertas { get; }
    public override TipoVehiculo Tipo => TipoVehiculo.Automovil;

    public Automovil(string marca, string modelo, int año, TipoCombustible combustible, int puertas)
        : base(marca, modelo, año)
    {
        Combustible = combustible;
        NumeroPuertas = puertas;
    }

    public void Reabastecer(double cantidad) =>
        Console.WriteLine($"Reabasteciendo {cantidad} litros de {Combustible} en el automóvil {Marca} {Modelo}.");

    public override string ObtenerInformacion() =>
        $"Automóvil {Marca} {Modelo} ({Año}) - {NumeroPuertas} puertas, Combustible: {Combustible}";

    public override void Arrancar() =>
        Console.WriteLine($"Girando la llave para arrancar el automóvil {Marca} {Modelo}.");
}

// Clase concreta Bicicleta corregida (renombrada propiedad Tipo a Categoria)
public class Bicicleta : VehiculoBase
{
    public string Categoria { get; } // Montaña, Ciudad, etc.
    public override TipoVehiculo Tipo => TipoVehiculo.Bicicleta;

    public Bicicleta(string marca, string modelo, int año, string categoria)
        : base(marca, modelo, año)
    {
        Categoria = categoria;
    }

    public override string ObtenerInformacion() =>
        $"Bicicleta {Marca} {Modelo} ({Año}) - Categoría: {Categoria}";

    public override void Arrancar() =>
        Console.WriteLine($"Comenzando a pedalear la bicicleta {Marca} {Modelo}.");

    public override void Detener() =>
        Console.WriteLine($"Frenando la bicicleta {Marca} {Modelo}.");
}

// Programa principal para mostrar el uso
class Programa
{
    static void Main()
    {
        List<IVehiculo> vehiculos = new()
        {
            new Automovil("Toyota", "Corolla", 2022, TipoCombustible.Gasolina, 4),
            new Bicicleta("Trek", "Mountain", 2023, "Montaña"),
            new Automovil("Tesla", "Model 3", 2023, TipoCombustible.Electrico, 4)
        };

        foreach (var vehiculo in vehiculos)
        {
            Console.WriteLine("\n" + vehiculo.ObtenerInformacion());
            vehiculo.Arrancar();
            vehiculo.Detener();

            if (vehiculo is IMotorizado motorizado)
                motorizado.Reabastecer(20.5);
        }
    }
}
