export interface User {
    id: string;
    email: string;
    firstName: string;
    lastName: string;
    password: string;
    authority: boolean;
  }
  
  export interface UserData {
    id: string;
    data: User;
  }
  
  export interface GetUsers {
    value: UserData;
    statusCode: any;
  }