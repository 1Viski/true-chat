# true:chat

Azure deployment [true:chat](https://wa-true-chat-client.azurewebsites.net/)

## For local development

Add to `secrets.json`

```json
{
  "ConnectionStrings": {
    "AzureDb": "{CONNECTION_STRING_TO_AZURE_DB}"
  },
  "Azure": {
    "SignalR": {
      "ConnectionString": "Endpoint={YOUR_ENDPOINT_TO_AZURE_SIGNALR};AccessKey={YOUR_ACCESS_KEY_TO_AZURE_SIGNALR};Version=1.0;"
    },
    "TextAnalytics": {
      "Endpoint": "{YOUR_ENDPOINT_TO_TEXT_ANALYTICS_API}",
      "Ke1": "{YOUR_KEY1_TO_TEXT_ANALYTICS_API}",
      "Key2": "{CONNECTION_STRING_TO_AZURE_DB}"
    }
  }
}
```

Alternative:
```json
{
  "Azure:SignalR:ConnectionString": "Endpoint={YOUR_ENDPOINT_TO_AZURE_SIGNALR};AccessKey={YOUR_ACCESS_KEY_TO_AZURE_SIGANLR};Version=1.0;",
  "Azure:TextAnalytics:Endpoint": "{YOUR_ENDPOINT_TO_TEXT_ANALYTICS_API}",
  "Azure:TextAnalytics:Key1": "{YOUR_KEY1_TO_TEXT_ANALYTICS_API}",
  "Azure:TextAnalytics:Key2": "{YOUR_KEY2_TO_TEXT_ANALYTICS_API}",
  "ConnectionStrings:AzureDb": "{CONNECTION_STRING_TO_AZURE_DB}"
}
```


