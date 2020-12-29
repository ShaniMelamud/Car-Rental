import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-car-photo',
    templateUrl: './car-photo.component.html',
    styleUrls: ['./car-photo.component.css']
})
export class CarPhotoComponent {

    @Input()
    public imageSource: string;
    @Input()
    public imageWidth: number;
    @Input()
    public imageHeight: number;




}
