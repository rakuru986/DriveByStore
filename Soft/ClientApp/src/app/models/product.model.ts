export interface Product {
  id: string;
  productCategoryId: string;
  productCategory: any;
  name: string;
  price: number;
  stock: number;
  image: string;
  description: string;
}

export interface ProductData {
  id: string;
  data: Product;
}

export interface GetProducts {
  value: ProductData;
  statusCode: any;
}

// constructor(productCategoryId, id, name, manufactorer, price = 0, image = "assets/images/noimageavailable.jpg", description = "No description") {
//   this.productCategoryId = productCategoryId
//   this.id = id
//   this.name = name
//   this.manufactorer = manufactorer
//   this.price = price
//   this.image = image
//   this.description = description
// }
