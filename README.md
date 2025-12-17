# YiJingLibrary

[English](README.md) | [中文](README_zh.md)

YiJingLibrary is a comprehensive .NET 10.0 library for Chinese metaphysics calculations, specifically focusing on Yi Jing (I Ching) divination. The library is composed of three main projects that work together to provide a complete solution for Yi Jing practitioners and researchers.

## Projects Overview

### 1. YiJingLibrary.Core

This is the core library containing fundamental elements of Yi Jing philosophy and calculations.

**Purpose:**
- Defines the basic elements of Yi Jing theory
- Implements core concepts such as Yin-Yang, Five Elements, Trigrams, Hexagrams
- Provides foundational classes for all other components

**Key Features:**
- Implementation of Yin-Yang theory
- Five Elements (Wood, Fire, Earth, Metal, Water) with their generation and restriction relationships
- Trigrams (Ba Gua) representation
- Sixty-four Hexagrams with complete symbolic meanings
- Stem-Branch calculations for Chinese calendar

**Main Classes:**
- `YinYang` - Represents the fundamental duality concept
- `FivePhase` - Implementation of the Five Elements theory
- `Trigram` - The eight trigrams of Yi Jing
- `Hexagram` - The sixty-four hexagrams with detailed attributes
- `StemBranch` - Chinese calendar stem-branch combinations
- `Line` - Individual lines that compose hexagrams

### 2. YiJingLibrary.ChineseLunarCalendar

This library handles conversions between Gregorian and Chinese lunar calendars.

**Purpose:**
- Converts Gregorian dates to Chinese lunar calendar dates
- Calculates stem-branch combinations for years, months, days, and hours
- Provides integration with external lunar calendar libraries

**Key Features:**
- Accurate conversion between solar and lunar dates
- Calculation of heavenly stems and earthly branches
- Support for Chinese traditional calendar systems
- Integration with external `Lunar` library for enhanced functionality

**Main Classes:**
- `InquiryTime` - Represents a specific moment for divination with both solar and lunar representations
- `LunarStemBranch` - Container for year, month, day, and hour stem-branch combinations
- `LunarAdapter` - Adapter for external lunar calendar library
- `LunarExtension` - Extension methods for DateTime conversion

### 3. YiJingLibrary.SixLines

This library implements the Six Lines (Liu Yao) divination system, a popular method of Yi Jing divination.

**Purpose:**
- Implements the Six Lines divination methodology
- Provides tools for creating and analyzing hexagrams
- Supports various divination approaches (manual, numerical, time-based)

**Key Features:**
- Complete Six Lines divination system implementation
- Automatic calculation of hexagram attributes (Six Kins, Six Spirits, Four Symbols)
- Support for hidden spirits and special hexagram features
- Multiple divination methods (manual input, random numbers, time-based)
- Extensive collection of spiritual and malign influences (Shen Sha)

**Main Classes:**
- `SixLinesDivination` - Main class representing a complete divination chart
- `SixKin` - The Six Kins relationship system (Parents, Siblings, Wealth, etc.)
- `SixSpirit` - The Six Spirits symbolism (Azure Dragon, Vermilion Bird, etc.)
- `Position` - Worldly and Corresponding positions in hexagrams
- `SpiritAndMalignity` - Various spiritual and malign influences
- `DefaultDivinationBuilder` - Builder pattern implementation for creating divination charts

## Installation

To use the YiJingLibrary in your project, you can reference the individual packages:

```xml
<PackageReference Include="YiJingLibrary.Core" Version="1.0.0" />
<PackageReference Include="YiJingLibrary.ChineseLunarCalendar" Version="1.0.0" />
<PackageReference Include="YiJingLibrary.SixLines" Version="1.0.0" />
```

Or clone the repository and build from source:

```bash
git clone https://github.com/TheodoreCheung/YiJingLibrary.git
cd YiJingLibrary
dotnet build
```

## Usage Examples

### 1. Basic Hexagram Creation

```csharp
using YiJingLibrary.Core;

// Create a specific hexagram
var hexagram = Hexagram.TheCreative; // The Creative hexagram
// or
var hexagram = Hexagram.FromValue(0b0111_0111); // The Creative hexagram

// Access hexagram properties
Console.WriteLine($"Hexagram: {hexagram}");
Console.WriteLine($"Palace: {hexagram.Palace}");
Console.WriteLine($"Upper Trigram: {hexagram.Upper}");
Console.WriteLine($"Lower Trigram: {hexagram.Lower}");

// Access individual lines
Console.WriteLine($"First line: {hexagram[1]}");
Console.WriteLine($"Second line: {hexagram[2]}");
Console.WriteLine($"Third line: {hexagram[3]}");
Console.WriteLine($"Fourth line: {hexagram[4]}");
Console.WriteLine($"Fifth line: {hexagram[5]}");
Console.WriteLine($"Top line: {hexagram[6]}");
// or
for (byte i = 1; i <= 6; i++)
{
    Console.WriteLine($"Line {i}: {hexagram[i]}");
}
```

### 2. Chinese Calendar Conversion

```csharp
using YiJingLibrary.ChineseLunarCalendar;

// Create an inquiry time from a Gregorian date
var solarDate = new DateTimeOffset(2023, 10, 15, 14, 30, 0, TimeSpan.Zero);
var inquiryTime = new InquiryTime(solarDate);

// Access lunar calendar information
Console.WriteLine($"Solar Date: {inquiryTime.Solar}");
Console.WriteLine($"Lunar Date: {inquiryTime.Lunar}");
Console.WriteLine($"Year Stem-Branch: {inquiryTime.Lunar.Year}");
Console.WriteLine($"Month Stem-Branch: {inquiryTime.Lunar.Month}");
Console.WriteLine($"Day Stem-Branch: {inquiryTime.Lunar.Day}");
Console.WriteLine($"Hour Stem-Branch: {inquiryTime.Lunar.Hour}");
```

### 3. Six Lines Divination

```csharp
using YiJingLibrary.SixLines;
using YiJingLibrary.ChineseLunarCalendar;

// Create a time-based divination
var solarDate = new DateTimeOffset(2023, 10, 15, 14, 30, 0, TimeSpan.Zero);
var builder = SixLines.CreateTimeDivinationBuilder(solarDate);

// Build the divination chart
var divination = builder.Build();

// Display the results
Console.WriteLine(divination.ToString());

// Manual divination with specific Four Symbols
var fourSymbols = new[]
{
    FourSymbol.YoungYang,  // Bottom line
    FourSymbol.OldYin,     // Second line
    FourSymbol.YoungYang,  // Third line
    FourSymbol.YoungYin,   // Fourth line
    FourSymbol.OldYang,    // Fifth line
    FourSymbol.YoungYin    // Top line
};

var manualBuilder = SixLines.CreateManualDivinationBuilder(solarDate, fourSymbols);
var manualDivination = manualBuilder.Build();

Console.WriteLine(manualDivination.ToString());
```

## Advanced Features

### Custom Divination Builder

You can customize the divination building process by providing your own builder implementation:

```csharp
var customBuilder = SixLines.CreateTimeDivinationBuilder(
    solarDate,
    divination => new CustomDivinationBuilder { BasicDivination = divination }
);

var customDivination = customBuilder.Build();
```

### Configuration Options

The library supports configuration for cultural settings:

```csharp
var builder = SixLines.CreateTimeDivinationBuilder(solarDate)
    .Configure(options => options.SetCulture("zh-CN"));

var divination = builder.Build();
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Inspired by traditional Chinese metaphysics and Yi Jing philosophy
- Uses external lunar calendar calculation libraries for accurate conversions
- Designed for both practitioners and researchers of Chinese divination systems