# 易经类库 (YiJingLibrary)

[English](README.md) | [中文](README_zh.md)

易经类库是一个综合性的.NET 10.0 库，专门用于中国玄学计算，重点是易经占卜。该类库由三个主要项目组成，共同提供了一个完整的易经实践和研究解决方案。

## 项目概述

### 1. YiJingLibrary.Core

这是包含易经理论和计算基础元素的核心库。

**用途:**
- 定义易经理论的基本元素
- 实现核心概念如阴阳、五行、八卦、六十四卦
- 为所有其他组件提供基础类

**主要功能:**
- 阴阳理论的实现
- 五行（木、火、土、金、水）及其相生相克关系
- 八卦表示
- 六十四卦及详细属性
- 天干地支计算

**主要类:**
- `YinYang` - 表示基本的二元性概念
- `FivePhase` - 五行理论的实现
- `Trigram` - 八卦
- `Hexagram` - 六十四卦及详细属性
- `StemBranch` - 中国农历的天干地支组合
- `Line` - 构成卦象的单个爻

### 2. YiJingLibrary.ChineseLunarCalendar

这个库处理公历和中国农历之间的转换。

**用途:**
- 公历日期转换为中国农历日期
- 计算年、月、日、时的天干地支组合
- 提供与外部农历库的集成

**主要功能:**
- 公历和农历日期的精确转换
- 天干地支的计算
- 支持中国传统历法系统
- 与外部`Lunar`库集成以增强功能

**主要类:**
- `InquiryTime` - 表示占卜的特定时刻，包含公历和农历表示
- `LunarStemBranch` - 年、月、日、时天干地支组合的容器
- `LunarAdapter` - 外部农历库的适配器
- `LunarExtension` - 日期时间转换的扩展方法

### 3. YiJingLibrary.SixLines

这个库实现了六爻占卜系统，这是一种流行的易经占卜方法。

**用途:**
- 实现六爻占卜方法论
- 提供创建和分析卦象的工具
- 支持各种占卜方法（手工、数字、时间）

**主要功能:**
- 完整的六爻占卜系统实现
- 自动计算卦象属性（六亲、六神、四象）
- 支持伏神和特殊卦象特征
- 多种占卜方法（手工输入、随机数、时间）
- 大量神煞影响的集合

**主要类:**
- `SixLinesDivination` - 表示完整占卜图的主要类
- `SixKin` - 六亲关系系统（父母、兄弟、妻财等）
- `SixSpirit` - 六神象征（青龙、朱雀等）
- `Position` - 世应位置
- `SpiritAndMalignity` - 各种神煞影响
- `DefaultDivinationBuilder` - 创建占卜图的构建器模式实现

## 安装

要在您的项目中使用易经类库，您可以引用各个包：

```xml
<PackageReference Include="YiJingLibrary.Core" Version="1.0.0" />
<PackageReference Include="YiJingLibrary.ChineseLunarCalendar" Version="1.0.0" />
<PackageReference Include="YiJingLibrary.SixLines" Version="1.0.0" />
```

或者克隆仓库并从源码构建：

```bash
git clone https://github.com/TheodoreCheung/YiJingLibrary.git
cd YiJingLibrary
dotnet build
```

## 使用示例

### 1. 基本卦象创建

```csharp
using YiJingLibrary.Core;

// 创建特定卦象
var hexagram = Hexagram.TheCreative; // 乾为天卦
// 或
var hexagram = Hexagram.FromValue(0b0111_0111); // 乾为天卦

// 访问卦象属性
Console.WriteLine($"卦象: {hexagram}");
Console.WriteLine($"卦宫: {hexagram.Palace}");
Console.WriteLine($"上卦: {hexagram.Upper}");
Console.WriteLine($"下卦: {hexagram.Lower}");

// 访问单个爻
Console.WriteLine($"初爻：{hexagram[1]}");
Console.WriteLine($"二爻：{hexagram[2]}");
Console.WriteLine($"三爻：{hexagram[3]}");
Console.WriteLine($"四爻：{hexagram[4]}");
Console.WriteLine($"五爻：{hexagram[5]}");
Console.WriteLine($"上爻：{hexagram[6]}");
// or
for (byte i = 1; i <= 6; i++)
{
    Console.WriteLine($"第{i}爻: {hexagram[i]}");
}
```

### 2. 中国农历转换

```csharp
using YiJingLibrary.ChineseLunarCalendar;

// 从公历日期创建占卜时间
var solarDate = new DateTimeOffset(2023, 10, 15, 14, 30, 0, TimeSpan.Zero);
var inquiryTime = new InquiryTime(solarDate);

// 访问农历信息
Console.WriteLine($"公历日期: {inquiryTime.Solar}");
Console.WriteLine($"农历日期: {inquiryTime.Lunar}");
Console.WriteLine($"年干支: {inquiryTime.Lunar.Year}");
Console.WriteLine($"月干支: {inquiryTime.Lunar.Month}");
Console.WriteLine($"日干支: {inquiryTime.Lunar.Day}");
Console.WriteLine($"时干支: {inquiryTime.Lunar.Hour}");
```

### 3. 六爻占卜

```csharp
using YiJingLibrary.SixLines;
using YiJingLibrary.ChineseLunarCalendar;

// 基于时间的占卜
var solarDate = new DateTimeOffset(2023, 10, 15, 14, 30, 0, TimeSpan.Zero);
var builder = SixLines.CreateTimeDivinationBuilder(solarDate);

// 构建占卜图
var divination = builder.Build();

// 显示结果
Console.WriteLine(divination.ToString());

// 使用特定四象的手工占卜
var fourSymbols = new[]
{
    FourSymbol.YoungYang,  // 初爻
    FourSymbol.OldYin,     // 二爻
    FourSymbol.YoungYang,  // 三爻
    FourSymbol.YoungYin,   // 四爻
    FourSymbol.OldYang,    // 五爻
    FourSymbol.YoungYin    // 上爻
};

var manualBuilder = SixLines.CreateManualDivinationBuilder(solarDate, fourSymbols);
var manualDivination = manualBuilder.Build();

Console.WriteLine(manualDivination.ToString());
```

## 高级功能

### 自定义占卜构建器

您可以通过提供自己的构建器实现来自定义占卜构建过程：

```csharp
var customBuilder = SixLines.CreateTimeDivinationBuilder(
    solarDate,
    divination => new CustomDivinationBuilder { BasicDivination = divination }
);

var customDivination = customBuilder.Build();
```

### 配置选项

类库支持文化设置的配置：

```csharp
var builder = SixLines.CreateTimeDivinationBuilder(solarDate)
    .Configure(options => options.SetCulture("zh-CN"));

var divination = builder.Build();
```

## 贡献

欢迎贡献！请随时提交拉取请求。

1. Fork 仓库
2. 创建您的功能分支 (`git checkout -b feature/AmazingFeature`)
3. 提交您的更改 (`git commit -m 'Add some amazing feature'`)
4. 推送到分支 (`git push origin feature/AmazingFeature`)
5. 打开拉取请求

## 许可证

该项目基于MIT许可证 - 详情请见 [LICENSE](LICENSE) 文件。

## 致谢

- 受传统中国玄学和易经理论启发
- 使用外部农历计算库实现精确转换
- 专为易经实践者和研究人员设计