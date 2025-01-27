# Business Logic Katmanı 

Business katmanı, presentation katmanından gelen komutların kontrollerinin gerçekleştiği kısımdır.
Aslında temelde "Data Access Layer" katmanındaki işlemleri yazmış oluyoruz ama burada validation ve 
kontrol işlemlerini eklemiş oluruz.
 
#### **1. İş kurallarına göre uygulama**
    - Örneğin
        - bir ürünün stokta olup olmadığının
        - kullanıcı girişi sırasında parola politikaları
        - sipariş tutarına göre indirim hesaplama

**Örneğin;**

Presentation katmanında "Satın Al" butonuna basılmasıyla
- ürünün stok durumu
- ödeme işlemi için bakiyenin kontrolü
- satın alma sayfasına yönlendirme
- ve alınan ürün kadar stoktan düşme 


##### **2. Validasyon (Doğrulama)**
    - Email formatının doğru olup olmadığı belirleme
    - Bir sipariş sırasında ürün miktarının pozitif değerde olmasını sağlama








