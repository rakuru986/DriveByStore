import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }

  sendOrderUrl = "https://localhost:44352/order/createOrder"



  async placeOrder(orderForm, products, orderTotal) {    

    let orderProductList = [];
    for (var value of products){
        orderProductList.push({"productId":value.productId,"quantity":value.qty});
    }
    const obj = {
        "address": orderForm.address,
        "city": orderForm.city,
        "email": orderForm.email,
        "phone": orderForm.phoneNumber,
        "zip": orderForm.zip,
        "total": orderTotal,
        "productList": orderProductList,
    }

    return this.http.post<any>(this.sendOrderUrl, obj, {observe:"response"})
        .toPromise()
        .then(response => {
            console.log(response);
        });    
    
  }

//   getAllOrders() {
//     return this.db.list('/order');
//   }

//   getOrderByUser(userId: string) {
//     return this.db.list('/order', {
//       query: {
//         orderByChild: 'user/userId',
//         equalTo: userId
//       }
//     });
//   }

//   getOrderById(orderId: string) {
//     return this.db.object('/order/' + orderId);
}
