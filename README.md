# IntergalacticExplorationMissions

## Bibliografia
Alamán, R. (s. f.). Apuntes M03Uf5. https://docs.google.com/document/d/1JJhB0bqxqns69wKZyF-s8eacxkzv55gO-ez6QvXEvhw/edit#heading=h.4heg8liyhxx. https://docs.google.com/document/d/1JJhB0bqxqns69wKZyF-s8eacxkzv55gO-ez6QvXEvhw/edit#heading=h.4heg8liyhxx.

BillWagner. (2024, 21 febrero). Grouping Data (C#) - C#. Microsoft Learn. https://learn.microsoft.com/en-us/dotnet/csharp/linq/standard-query-operators/grouping-data

##Gpt 

Promt:

Tengo  una clase person, atibutos A ,B y C. En una lista de person quiero filtra a todos los que tengan el atributo B y entre ellos filtra a los que tenfa C==0 y sin  repetir el atributo A.

Retorno:

    public class Person
    {
    public int A { get; set; }
    public int B { get; set; }
    public int C { get; set; }
    }

    class Program
    {
    static void Main()
    {
        // Ejemplo de lista de Personas
        List<Person> personas = new List<Person>
        {
            new Person { A = 1, B = 10, C = 0 },
            new Person { A = 2, B = 20, C = 1 },
            new Person { A = 1, B = 30, C = 0 },
            new Person { A = 3, B = 40, C = 0 },
            new Person { A = 2, B = 50, C = 1 }
        };

        // Filtrar por B y C
        var filtrado = personas.Where(p => p.B == 30 && p.C == 0);

        // Eliminar duplicados en A
        var unicos = filtrado.GroupBy(p => p.A).Select(g => g.First());

        // Mostrar resultados
        foreach (var persona in unicos)
        {
            Console.WriteLine($"A: {persona.A}, B: {persona.B}, C: {persona.C}");
        }
      }
    }
