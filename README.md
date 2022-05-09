
<h1>N - KATMANLI MİMARİLER İÇİN KOD OLUŞTURUCU</h1>

<h2>Code Generator Project</h2>
<p> 
   <h4>Programın çalışır halinin videosunu, dosyanın en altındaki play butonuna basarak izleyebilirsiniz.</h4>
   
   <h4>
     <i>
       Çok katmanlı mimari ile geliştilen projelerde, yeni bir <b>Entity</b> ekleneceği zaman tüm katmanlarda <b>(DataAccess, Business ..) ilgili entity için en az birer tane <b>'Interface' ve bu Interface kalıtım alan bir 'Class'</b> oluşturmak gerekmektedir. Bu işlem başlangıçta zevkli olsada bir yerden sonra sürekli kendini tekrar eder bir hal almaktadır ve bu durum can sıkıcı olabilmektedir. <b>(Dont repeat yourself.)</b>
       <p>
       CodeGenerator projesi içerisinde yapılmış olan geliştirme sayesinde;
       > İlk olarak <b>Database</b> ile bağlantımızı oluşturacak class olan <b>Context Class</b>'ımızı oluşturmaktadır.
       
       > Entity katmanında oluşturulan <b>Model Class</b> referans alınarak, DataAccess katmanında bulunan <b>Abstract</b> klasörü içerisine ilgili entity için bir adet <b>Interface</b> oluşturmaktadır. Daha sonra DataAccess içerisinde bulunan <b>Concrete</b> klasörü içerisine Class'ını oluşturarak Interface ile kalıtım almaktadır ve ilgili Entity için DataAccess katmanındaki database işlemleri için gerekli hazırlıkları tamamlamaktadır.
       
       > Business katmanında <b>Abstract ve Concrete</b> klasöründe Interface ve Class'ları oluşturduktan sonra Business katmanı ile DataAccess katmanı arasındaki köprüde kurulmuş olmaktadır.
      </p>
     </i>
       
       <i><u>NOT:</u> proje henüz tamamlanmamış olup basic düzeyde tutulmuştur. İhtiyaca göre geliştirmeye açıktır ve devam edilecektir. Windows ve Macbook larda dosya yollarında farklılık olacaktır. Dosya yolları, Windows'ta '\\' olması gerekirken Maclerde '/' olarak değiştirilmesi gerekmektedir. İlerleyen süreçlerde, dosya yolları <b>Config</b> dosyasından okunacak, <b>Web</b> projesi eklenerek <b>Register</b> işlemi yapılacak ve <b>Dependency Injection</b> blokları otomatik oluşturulacak.</i>
   </h4>
     
     <hr/>
</p>



https://user-images.githubusercontent.com/30552914/167453390-71ae0abb-5f84-4bbd-a91c-1512996592ba.MP4

