import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";
import { giftList } from "../../Models/giftList.model";

export function uniqueValidator(): ValidatorFn {
    let l: any = ["car","book","doll","cliner to a year","silver dishes","5,000$"]
    return (control: AbstractControl): ValidationErrors | null => {
        if (l && control.value) {
            for (let i = 0; i < l.length; i++) {
                if (l[i] == control.value)
                    return { uniquepParam: { value: control.value } };
            }
            l.push(control.value)
        }
        return null;
    }
}