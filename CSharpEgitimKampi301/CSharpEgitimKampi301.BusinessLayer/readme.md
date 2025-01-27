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

#### Dependency Injections

 Amaç, bir sınıfın bağımlı olduğu nesneleri (dependencileri) kendisinin oluşturmaması, 
 bunun yerine dışarıdan almasıdır. Bu yaklaşım, kodun daha modüler, test edilebilir ve bakımının kolay olmasını sağlar.

**Temel Fikir:**
Bir sınıfın, diğer sınıflara veya bileşenlere olan bağımlılıklarını, kendisi yaratmak yerine dışarıdan bir yerden almasıdır.

> .NET Core da daha efektif kullanılan bir yapıdır.

##### Neden Kullanılır?

1. **Gevşek Bağlılık (Loose Coupling):** Bir sınıfın diğer sınıflara doğrudan bağımlı olması yerine, bu bağımlılıkların dışarıdan verilmesi, kodun daha esnek ve bağımsız olmasını sağlar.
2. **Test Edilebilirlik:** Mock ya da stub nesneleri kullanarak bağımlılıkların kolayca değiştirilmesi, birim testlerin yazılmasını kolaylaştırır.
3. **Yeniden Kullanılabilirlik:** Aynı bağımlılıklar birden fazla sınıf tarafından paylaşılabilir.
4. **Bakım Kolaylığı:** Kodun modüler bir yapıda olması, geliştirme ve hata giderme süreçlerini kolaylaştırır.

### Türleri:

1. **Constructor Injection (Yapıcı Yöntemle Enjeksiyon):** Bağımlılıklar sınıfın constructor (yapıcı) metodu aracılığıyla sağlanır.
   
   ```java
   public class Service {
       private final Repository repository;
   
       public Service(Repository repository) {
           this.repository = repository;
       }
   
       public void execute() {
           repository.doSomething();
       }
   }
   
   ```

2. **Setter Injection (Set Metodu ile Enjeksiyon):** Bağımlılıklar setter metotları aracılığıyla sağlanır.
   
   ```java
   public class Service {
       private Repository repository;
   
       public void setRepository(Repository repository) {
           this.repository = repository;
       }
   
       public void execute() {
           repository.doSomething();
       }
   }
   
   ```

3. **Field Injection (Alan Enjeksiyonu):** Bağımlılıklar doğrudan bir sınıfın alanına enjekte edilir. Bu genelde bir DI çerçevesi (Spring, Guice vb.) ile yapılır.
   
   ```java
   public class Service {
       @Inject
       private Repository repository;
   
       public void execute() {
           repository.doSomething();
       }
   }
   
   ```
   
   
