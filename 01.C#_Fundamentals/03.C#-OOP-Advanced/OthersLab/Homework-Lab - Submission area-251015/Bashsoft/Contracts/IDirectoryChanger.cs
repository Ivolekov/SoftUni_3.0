namespace Lab.AdvancedCSharp.Bashsoft.Contracts
{
    public interface IDirectoryChanger
    {
        void ChangeDirectoryRelative(string relativePath);

        void ChangeDirectoryAbsolute(string absolutePath);
    }
}
