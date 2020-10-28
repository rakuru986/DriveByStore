export class Product{    
    productCategoryId: number;
    id: number;    
    name: string;
    manufactorer: string;
    price: number;    
    //stock: number;
    image: string;
    description: string;
      

    constructor(productCategoryId, id, name, manufactorer, price = 0, image = "assets/images/noimageavailable.jpg", description = "No description") {      
      this.productCategoryId = productCategoryId
      this.id = id
      this.name = name
      this.manufactorer = manufactorer
      this.price = price      
      this.image = image
      this.description = description
    }

  }
