namespace Events;

/*
Navrhněte třídu, která bude mít událost.
Událost bude obsloužena generickým event handlerem.
Jako argumenty zvolte specifickou, Vámi vytvořenou třídu.
Umožněte spuštění události, předání parametrů události,
které předáte dál do argumentů události.

Zachyťte událost metodou, ověřte, že odesílatel je ten, kdo by to měl být
a použijte argumenty události.
 */
internal class Task
{
    public event EventHandler<SampleImmutableEventArgs>? SampleEvent;

    // Trigger

    // Použití
}
