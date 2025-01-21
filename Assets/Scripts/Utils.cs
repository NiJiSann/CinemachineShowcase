public static class Utils
{
    public static int CyclicClampIndex(int index, int max)
    {
        var mod = index % max;
        return mod < 0 ? max + mod : mod;
    }
}