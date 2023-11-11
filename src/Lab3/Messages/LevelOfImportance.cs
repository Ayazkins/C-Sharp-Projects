namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public abstract record LevelOfImportance
{
    private LevelOfImportance() { }

    public abstract int Value();

    public record FirstLevelOfImportance() : LevelOfImportance
    {
        public override int Value()
        {
            return 0;
        }
    }

    public record SecondLevelOfImportance() : LevelOfImportance
    {
        public override int Value()
        {
            return 1;
        }
    }

    public record ThirdLevelOfImportance() : LevelOfImportance
    {
        public override int Value()
        {
            return 2;
        }
    }
}