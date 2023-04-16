import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CategoryDto } from '../Dtos/CategoryDto';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private httpClient: HttpClient, @Inject('API_Url') private baseurl: string) { }

  getAll(): Observable<CategoryDto[]> {
    return new Observable<CategoryDto[]>(observer => {
      this.httpClient.get<CategoryDto[]>(this.baseurl + "/category/getall").subscribe(data => {
        observer.next(data);
      }, err => {
        //this.showNotification(err, block);
      })
    });
  }

  getById(id: string): Observable<CategoryDto> {
    return new Observable<CategoryDto>(observer => {
      this.httpClient.get<CategoryDto>(this.baseurl + "/category/getbyid/" + id).subscribe(
        //observer.next(data);
        data => observer.next(data),
        err => console.error('Observer got an error: ' + err),
        () => console.log('Observer got a complete notification')
      );
    });
  }
}
