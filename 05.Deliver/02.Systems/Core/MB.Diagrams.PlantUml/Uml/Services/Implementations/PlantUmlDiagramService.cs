using MB.Diagrams.PlantUml;
using MB.Diagrams.PlantUml.Uml;

namespace App.Diagrams.PlantUml.Uml.Services.Implemtations
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Net;
    //using System.Net.Http;
    using System.Net.Http;
    using System.Text;
    using App.Diagrams.PlantUml.Uml.Services.Configuration;

    /// <summary>
    /// An implementation of the <see cref="IPlantUmlDiagramService"/>
    /// <para>
    /// Invoked by <see cref="INetClassDiagramPlantUmlDiagramService"/>
    /// </para>
    /// </summary>
    public class PlantUmlDiagramService : IPlantUmlDiagramService
    {

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IPlantUmlDiagramServiceConfiguration Configuration
        {
            get { return _plantUmlDiagramServiceConfiguration; }
        }
        private readonly IPlantUmlDiagramServiceConfiguration _plantUmlDiagramServiceConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlantUmlDiagramService"/> class.
        /// </summary>
        public PlantUmlDiagramService(IPlantUmlDiagramServiceConfiguration plantUmlDiagramServiceConfiguration)
        {
            _plantUmlDiagramServiceConfiguration = plantUmlDiagramServiceConfiguration;
        }


        /// <summary>
        /// Develops the url to the remote diagram image.
        /// </summary>
        /// <param name="diagramText">The diagram text.</param>
        /// <returns></returns>
        public string DevelopImageUrl(string diagramText, string imageFormat = "svg")
        {
            var result = 
                "{0}/{1}/{2}".FormatStringInvariantCulture(
                _plantUmlDiagramServiceConfiguration.ServerUrl, 
                imageFormat, 
                SerializeAndEncodeDiagramText(diagramText));

            return result;
        }

        /// <summary>
        /// Retrieves from the remote PlantUml server the image
        /// as a byte array.
        /// <para>
        /// The invoker must convert the byte array to a png/other format
        /// in a platform specific way -- as PCL does not provide such classes.
        /// </para>
        /// </summary>
        /// <param name="diagramText"></param>
        /// <returns></returns>
        public byte[] RetrieveImageAsByteArray(string diagramText)
        {
            var handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.GZip |
                                                 DecompressionMethods.Deflate;
            } 
            var httpClient = new HttpClient(handler);
            HttpResponseMessage response = httpClient.GetAsync(DevelopImageUrl(diagramText)).WaitAndGetResult();

            byte[] img = response.Content.ReadAsByteArrayAsync().WaitAndGetResult();

            //PCL does not provide graphics. Have to take byte array, to stream, to image.
            return img;
        }

        private string SerializeAndEncodeDiagramText(string diagramText)
        {
            byte[] compressed = Compress(diagramText);
            return Encode64(compressed);
        }


        private string Encode64(byte[] bytes)
        {
            StringBuilder buffer = new StringBuilder();

            for (var i = 0; i < bytes.Length; i += 3)
            {
                if (i + 2 == bytes.Length)
                {
                    buffer.Append(Append3Bytes(bytes[i], bytes[i + 1], 0));
                }
                else if (i + 1 == bytes.Length)
                {
                    buffer.Append(Append3Bytes(bytes[i], 0, 0));
                }
                else
                {
                    buffer.Append(Append3Bytes(bytes[i], bytes[i + 1], bytes[i + 2]));
                }
            }

            return buffer.ToString();
        }

        private string Append3Bytes(int b1, int b2, int b3)
        {
            const int sixtyThree = 0x3F;

            var c1 = b1 >> 2;
            var c2 = ((b1 & 0x3) << 4) | (b2 >> 4);
            var c3 = ((b2 & 0xF) << 2) | (b3 >> 6);
            var c4 = b3 & sixtyThree;

            return string.Concat(Encode6bit(c1 & sixtyThree), Encode6bit(c2 & sixtyThree), Encode6bit(c3 & sixtyThree), Encode6bit(c4 & sixtyThree));
        }


        private string Encode6bit(int b)
        {
            if (b < 10)
                return ConvertFromUtf32(48 + b);

            b -= 10;

            if (b < 26)
                return ConvertFromUtf32(65 + b);

            b -= 26;

            if (b < 26)
                return ConvertFromUtf32(97 + b);
            b -= 26;

            if (b == 0)
                return "-";

            if (b == 1)
                return "_";

            return "?";
        }


        static string ConvertFromUtf32(int utf32)
        {
            if (utf32 < 0 || utf32 > 1114111 || utf32 >= 55296 && utf32 <= 57343)
            {
                throw new ArgumentOutOfRangeException("utf32");
            }
            if (utf32 < 65536)
                return char.ToString((char)utf32);
            utf32 -= 65536;
            return new string(new char[2]
      {
        (char) (utf32 / 1024 + 55296),
        (char) (utf32 % 1024 + 56320)
      });
        }

		

        private static byte[] Compress(string text)
        {
            using (MemoryStream output = new MemoryStream())
            {
                using (DeflateStream gzip = new System.IO.Compression.DeflateStream(output, System.IO.Compression.CompressionMode.Compress))
                {
                    using (StreamWriter writer = new StreamWriter(gzip, System.Text.Encoding.UTF8))
                    {
                        writer.Write(text);
                    }
                }

                return output.ToArray();
            }
        }


    }
}