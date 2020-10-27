export class Product{    
    id: number;
    description: string;
    name: string;
    //manufactorer: string;
    price: number;
    productCategoryId: number;
    stock: number;
    image: string;
      

    constructor(productType, id, name, manufactorer, price = 0, productCategoryId, image = "assets/images/noimageavailable.jpg", description = "No description") {
      //this.productType = productType
      this.id = id
      this.name = name
      //this.manufactorer = manufactorer
      this.price = price
      this.productCategoryId = productCategoryId
      this.image = image
      this.description = description
    }

  }
