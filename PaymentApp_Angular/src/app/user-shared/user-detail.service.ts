import { Injectable } from '@angular/core';
import { UserDetail } from './user-detail.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class UserDetailService {
  formData: UserDetail;

  readonly rootUrl = 'http://localhost:1473/api';
  users: UserDetail[];

  constructor(private http: HttpClient) {}

  postUserDetail(formData: UserDetail) {
    // makes a POST request to the backend
    console.log(formData);
    return this.http.post(this.rootUrl + '/User', formData);
  }

  putUserDetail(formData: UserDetail) {
    // makes a PUT request to the backend to modify entry
    return this.http.put(this.rootUrl + '/User/' + formData.UserId, formData);
  }

  deleteUserDetail(UserId: number) {
    // makes a PUT request to the backend to modify entry
    return this.http.delete(this.rootUrl + '/User/' + UserId);
  }

  refreshList() {
    // referesh the list on the right to show a list with newly added information
    this.http
      .get(this.rootUrl + '/User')
      .toPromise()
      .then((res) => (this.users = res as UserDetail[]));
  }
}
