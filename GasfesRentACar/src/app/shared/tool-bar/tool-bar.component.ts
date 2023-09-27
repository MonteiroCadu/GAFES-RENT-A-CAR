import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { IonicModule } from '@ionic/angular';

@Component({
  selector: 'app-tool-bar',
  templateUrl: './tool-bar.component.html',
  styleUrls: ['./tool-bar.component.scss'],
  standalone: true,
  imports: [
    IonicModule,
    CommonModule
  ]
})
export class ToolBarComponent  implements OnInit {
  constructor() { }
  public _titleName: string= '';
  _goBackPage: boolean = true;

  @Input()
  set titleName(valor: string) {
    this._titleName = valor;
  }

  @Input()
  set goBackPage(value: boolean) {
    this._goBackPage = value;
  }

  showBacButton() {
    return this._goBackPage;
  }

  ngOnInit() {}

}
