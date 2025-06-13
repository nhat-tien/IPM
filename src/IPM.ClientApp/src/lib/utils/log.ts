import { dev } from "$app/environment";

export class AppLog {

  public static error(message: string, placeOccur?: string) {
    if(dev) console.table({ "[ERROR]": message, "Place occur": placeOccur});
  }

  public static cache(message: string) {
    if(dev) console.log(`[CACHE]: ` + message);
  }

  public static info(message: string) {
    if(dev) console.log(`[INFO]: ` + message);
  }
}
