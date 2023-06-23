namespace GraphQLClient.BlazorWebAssembly.Dtos;

    public class AssetDto
    {
        public string Name { get; set; } = string.Empty;
        public double LastPrice { get; set; }
    }

// Create DTO
// - Asset
//   - String Name              // [SDL] name: String!      [JSON] "name": "Aave"
//   - Price
//     - Double LastPrice       // [SDL] lastPrice: Float!  [JSON] "lastPrice": 180.41