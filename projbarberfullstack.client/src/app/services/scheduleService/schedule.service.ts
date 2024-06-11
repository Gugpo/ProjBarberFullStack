import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { Response } from '../../models/Response';
import { Schedule } from '../../models/Schedule';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {

  private apiUrl = `${environment.ApiUrl}`; 

  constructor(private http: HttpClient) { }

  GetSchedule(): Observable<Response<Schedule[]>>{
    return this.http.get<Response<Schedule[]>>(this.apiUrl);
  }
}
