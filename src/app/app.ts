import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SideBar } from './shared/components/side-bar/side-bar';
import { PagesModule } from './pages/pages-module';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, SideBar, PagesModule],
  standalone: true,
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('store-app');
}
