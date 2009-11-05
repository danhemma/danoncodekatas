namespace KataMinesweeper
{
    public class HintsPopulator
    {
        private readonly Field field;

        public HintsPopulator(Field field)
        {
            this.field = field;
        }

        public Field GetHints()
        {
            return field;
        }
    }
}