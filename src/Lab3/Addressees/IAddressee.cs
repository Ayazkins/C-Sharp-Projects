namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public interface IAddressee
{
    string Name { get; }
    void TakeMessage(Message message);
}