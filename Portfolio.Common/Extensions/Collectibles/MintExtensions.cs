using Portfolio.Common.Enums.Collectibles;

namespace Portfolio.Common.Extensions.Colectibles
{
    public static class MintExtensions
    {
        public static string ToMintMark(this Mint mint)
        {
            var mintMark = string.Empty;
            switch (mint)
            {
                case Mint.Unknown:
                    break;
                case Mint.Philadelphia:
                    mintMark = "P";
                    break;
                case Mint.Denver:
                    mintMark = "D";
                    break;
                case Mint.SanFrancisco:
                    mintMark = "S";
                    break;
                case Mint.WestPoint:
                    mintMark = "W";
                    break;
                case Mint.CarsonCity:
                    mintMark = "CC";
                    break;
                case Mint.Dahlonega:
                    mintMark = "D";
                    break;
                case Mint.Charlotte:
                    mintMark = "C";
                    break;
                case Mint.NewOrleans:
                    mintMark = "O";
                    break;
                default:
                    break;
            }

            return mintMark;
        }
    }
}