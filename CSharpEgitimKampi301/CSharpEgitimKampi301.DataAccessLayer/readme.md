Context

Context; database ile bağlantı tanımlamasını oluşturacağımız kısımdır.
database'e yansıyacak olan tabloları tuttuğumuz yer.

------------------------------------------------------
Bir tabloyu database'e yansıtmak istiyorsak "CampContext" in içine yazmamız gerekiyor.

-------------------------------------------------------
bu migration işlemi oluşturduğumuz model classlarına göre database de tablo oluşturumak anlamına gelir. 
Yani database tarafında el ile işlem yapmamıza gerek kalmaz.

-------------------------------------------------------
migration işlemi için aşağıdaki işlemler yapılır

View -> Other Windows -> Package Manager Console gir

*enable-migrations*   // migration işlemini aktifleştir
*update-database	*	// database i context'te göre tabloları oluştur.

örneğin customer entity'ye yeni bir alan eklenirse şunlar yapılır

*add-migration mig1*	// mig1 isimli yeni bir migration oluşturur
*update-database*		// yeni migration işlemini database'e yansıtır.

*add-migration mig1* işlemi sonrası *"202411130806488_mig1.cs"* isimli bir class eklenir. updata-database ile 
bu class içindeki yeni alanı gerekli tablo için eoluşturur.

---------------------------------------------------------

> [!WARNING] 
projedeki tüm entity fremawork versiyonları aynı olmalı, yoksa hata mesajları ile boğuşabilirsin.

---




