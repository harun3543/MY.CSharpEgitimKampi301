# EfProject katmanı
up:: [[01. M.Y.EgitimKampi.2024]]
date:: 2025-01-04

## Database First Nedir?

> Database First yaklaşımı ile database tabloları oluşturulduktan sonra tabloya yeni bir değer eklnediğinde mutlaka Visual Studio tarafında ".edmx" dosyasına gelip sağ tuştan **Update model from database** işlemini yapmamız gerekir.

### "DbFirst" ile tablo oluşturma yaklaşımı

1. Önce SSMS ile server'a bağlanıp *database* ve *tablolar* oluşturulup relationship var ise bu bağlantılar kurulur.
2. visual studio tarafında dönüp projeye "ADO.NET Entity Data Model" projeye eklenir. 

3. projeye ".edmx" uzantılı bir yapı eklenir. bu yapıda database de oluşturduğumuz tabloların model class'ları oluşur.


