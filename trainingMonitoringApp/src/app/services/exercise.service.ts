import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Exercise } from '../entity/exercise';
import { API_URL } from '../environments/environment ';
import { ExerciseModel } from '../models/exerciseModel';

@Injectable({
  providedIn: 'root',
})
export class ExerciseService {
  constructor(private http: HttpClient) {}

  getAllExercises(): Observable<ExerciseModel[]> {
    const token = localStorage.getItem('access_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
      'Content-Type': 'application/json',
    });

    return this.http.get<ExerciseModel[]>(`${API_URL}/exercise/all`, {
      headers,
    });
  }
  createExercise(newExercise: ExerciseModel): Observable<any> {
    const token = localStorage.getItem('access_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
      'Content-Type': 'application/json',
    });

    return this.http.post<ExerciseModel>(
      `${API_URL}/exercise/add`,
      newExercise,
      { headers }
    );
  }
}
