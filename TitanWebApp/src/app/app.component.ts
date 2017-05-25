import { Component } from '@angular/core';
import { BreadcrumbService} from 'ng2-breadcrumb/ng2-breadcrumb';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private breadcrumb: BreadcrumbService) {
    breadcrumb.hideRoute('/Home');
  }
  title = 'app works!';
}
