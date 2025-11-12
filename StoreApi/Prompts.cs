namespace StoreApi;

public class Prompts
{
    public static string GenerateOrdersPrompt(string jsonData)
    {
        return @$"
            Eres un analista experto de datos en retail.
            Analiza los siguientes datos de ordenes, productos y tiendas (en JSOn) {jsonData}

            Debes responder **exclusivamente** en formato JSON y con esta estructura:
                {{
                    ""topProducts"": {{""name"": string, ""unitsSold"": int, ""totalRevenue"": double}},
                    ""topStore"": {{""name"": string,""totalSales"": double,""shareOfTotalSales"": double}},
                    ""avgSpending"": double,
                    ""patterns"": [string]
                }}
                En el apartado de patterns agrega analisis como: cual es la tienda que mas vende,
                que productos son los que mas dinero dejan por orden.                

                Si por alguna razon no puedes generar esta respuesta valida (por ejemplo, te hacen 
                falta datos o tienes algun error en el formato), responde **SOLO** cpon el texto: 
                error.

                No me saludes, no me des explicaciones, no me des comentarios y no incluyas texto
                adicional
        ";
    }
    public static string GenerateInvoicesPrompt(string jsonData)
    {
        return @$"
        Eres un analista experto en finanzas y facturación.
        Analiza los siguientes datos de facturas en formato JSON: {jsonData}

        Debes responder **exclusivamente** en formato JSON con esta estructura exacta:
        {{
          ""totalInvoices"": int,
          ""paidInvoices"": int,
          ""unpaidInvoices"": int,
          ""totalRevenue"": double,
          ""averageInvoiceAmount"": double,
          ""commonCurrencies"": [string],
          ""patterns"": [string]
        }}

        En ""patterns"" incluye observaciones como:
        - Porcentaje de facturas pagadas (por ejemplo: ""El 70% de las facturas están pagadas"").
        - La moneda más utilizada.
        - Cualquier patrón relevante detectado (tendencias de montos, fechas de pago, etc.).

        Si por alguna razón no puedes generar una respuesta válida con ese JSON (por falta de datos o error de formato), responde **SOLO** el texto:
        error

        No me saludes, no expliques tu proceso, no agregues texto adicional fuera del JSON indicado, ni comentarios.
        ";
    }
}