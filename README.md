# About

A simple .NET utility to fetch source information for images and embed it in the EXIF data. Currently only supports adding it as the Image Description but this may change.

## How To Use

Clone the repo then run:

```
dotnet run ./path/to/image(s)
```

to apply the source information. This will add the first URL of the most similar match as the source.