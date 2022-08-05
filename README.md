# AtmRush

Level_Up Akademi bünyesinde 3 arkadaşım ile yaptığım projenin 
kaynak kodları.




## Ekip üyeleri

- Mehmet Salih Öncü (https://github.com/OncuMehmet)
- Hakan Melen (https://github.com/melenglobal)
- Furkan Tural (https://github.com/furkasf)



## UML

Atm Rush için proje başlamdan önce yaptığımız UML diagramı sürecde
kodu olabildiğince moduler ve dependency'i azaltmak adına bazı
değişililer yaptık managerların fonksiyon ve sinyalarini command'a
çevirmek gibi uml güncel değildir ama kod yapısı hakında genel bir fikir
almak için referans olarak kullanılabir.

NOT: UML güncel değildir.

![UMLFILE](https://user-images.githubusercontent.com/60402673/182665953-f327ea17-5af4-4c16-baa7-bbeedf6a006a.jpg)

## Kullanılan Unity Paketleri

- Toony Color
- DOTween
- Easy Save
- GUI Packages
- Volume profiler
- Cinemachine (State Driven Camera)


## Projede kullanılan Patternler

- Oberserver => genelikle maneerlar arasında iletişimi kurmak için
kullanıldı

- Singleton => Singletonı sade sinyaler ve object pool'u çağırmak
için kullandık

- ObjectPool => Pool'u oyunda level içinde atm'ye giren paraları
toplatıp mini game'de kullabılmek için kulandık bu şekilde her
mini game başladığıda instantiate ve destroydan kacındık oyunda
bu ikisi sade level'i load ve clear etmek için kullandık

- Command => managerlerın funksiyonların birbirlerine olan dependencylerini engellemek , managerların modüllerliğini arttırmak ve son olarakta 
    managerı kod sayısını minimize edip genel olarak kodu daha rahat maintain
    etmek için kullandık 
    
 ## Yapılan Mekanikler
 - Object Lerp
 - Stack
 - Change Mesh
 - Player, Object and Obtacle Animation
 - Mini Game


 ## Projeden Alınan Görseller
 ![1](https://user-images.githubusercontent.com/89360756/183089005-33f4fd81-4457-4f08-95c3-d563139d6978.png)
 ![2](https://user-images.githubusercontent.com/89360756/183089057-8e694455-0ee7-49b5-b6ff-82019f092f99.png)
 ![3](https://user-images.githubusercontent.com/89360756/183089075-3e4a134d-aba9-4a83-9857-c4dbada89803.png)
 ![6](https://user-images.githubusercontent.com/89360756/183089102-027dafb6-1d91-4295-819a-23024be367db.png)
 ![5](https://user-images.githubusercontent.com/89360756/183089131-48d84ae2-a2ae-47eb-abc7-56b860e7a1dc.png)





  
