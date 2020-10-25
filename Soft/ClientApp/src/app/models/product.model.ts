export class Product{
    productType: number;
    id: number;
    name: string;
    manufactorer: string;
    price: number;
    image: string;
    description: string;  

    constructor(productType, id, name, manufactorer, price = 0, image = "assets/images/noimageavailable.jpg", description = "No description") {
      this.productType = productType
      this.id = id
      this.name = name
      this.manufactorer = manufactorer
      this.price = price
      this.image = image
      this.description = description
    }

  }
