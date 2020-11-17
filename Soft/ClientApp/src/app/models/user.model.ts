export interface User {    
    email: string;
    firstName: string;
    lastName: string;
    phoneNumber: string;
    password: string;    
  }
  
  export interface UserData {
    id: string;
    data: User;
  }
  
  export interface GetUsers {
    value: UserData;
    statusCode: any;
  }