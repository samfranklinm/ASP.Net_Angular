import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UserDetail } from 'src/app/user-shared/user-detail.model';
import { UserDetailService } from 'src/app/user-shared/user-detail.service';

@Component({
  selector: 'app-user-detail-list',
  templateUrl: './user-detail-list.component.html',
  styles: [],
})
export class UserDetailListComponent implements OnInit {
  constructor(
    public service: UserDetailService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(pd: UserDetail) {
    this.service.formData = Object.assign({}, pd);
  }

  deleteUser(UserId) {
    if (confirm('Are you sure you want to delete this entry?')) {
      this.service.deleteUserDetail(UserId).subscribe(
        (res) => {
          this.service.refreshList();
          this.toastr.warning('Deleted successfully', 'User Form');
        },
        (err) => {
          console.log(err);
        }
      );
    }
  }
}
