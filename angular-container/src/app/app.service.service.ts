import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor(private http:HttpClient) { }

  getAllCloudProvider(){
    return this.http.get('http://localhost:1141/api/cloudprovider')
  }
}
