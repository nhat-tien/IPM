
export class AppLog {

  public static error(message: string, placeOccur?: string) {
    console.table({ "[ERROR]": message, "Place occur": placeOccur});
  }

  public static cache(message: string) {
    console.log(`>>> IPM [CACHE]: ` + message);
  }
}
