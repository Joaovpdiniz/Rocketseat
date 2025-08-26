internal class Calcular
{
    double num1 { get; set; }
    double num2 { get; set; }

    public void InformaNum()
    {
        Console.WriteLine("Informe o Primeiro Numero: ");
        num1 = double.Parse(Console.ReadLine());

        Console.WriteLine();

        Console.WriteLine("Informe o Segundo Numero: ");
        num2 = double.Parse(Console.ReadLine());


    }

    public void Executar()
    {

        InformaNum();
        Soma();
        Subtrai();
        Multiplica();
        Dividi();
        Media();
    }

    public void Soma()
    {

        Console.WriteLine($"A Soma entre {num1} e {num2} é igual a {num1 + num2}");
    }
    public void Subtrai()
    {
        Console.WriteLine($"A Subtração entre {num1} e {num2} é igual a {num1 - num2}");
    }
    public void Multiplica()
    {
        Console.WriteLine($"A Multiplicação entre {num1} e {num2} é igual a {num1 * num2}");
    }
    public void Dividi()
    {
        if (num2 != 0)
        {
            Console.WriteLine($"A Divisão entre {num1} e {num2} é igual a {num1 / num2}");
        }
        else
        {
            Console.WriteLine("Não é possivel dividr por zero");
        }
    }

    public void Media()
    {
        Console.WriteLine($"A Media entre {num1} e {num2} é igual a {(num1 + num2) / 2}");
    }


}