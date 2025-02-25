import { AppLog } from "../utils/log";

type Cache = {
  time: number,
  timeExpired: number // second
  data: any
}

let cache = $state(new Map<string, Cache>());

function isValid(time: number | undefined, timeExpired: number | undefined): boolean {
  if (!time || !timeExpired) {
    return false;
  }
  const milisec = Date.now() - time;
  return timeExpired > Math.floor(milisec / 1000);
}

export async function cacheFetch<T>(key: string, timeExpired: number, fetchCallback: () => Promise<T>): Promise<T> {
  //No cache
  if (!cache.has(key)) {

    const data: T = await fetchCallback();

    if (data != null) {
      cache.set(key, {
        time: Date.now(),
        timeExpired: timeExpired,
        data: data
      });
    }

    AppLog.cache("Miss cache");

    return new Promise((resolve, _) => {
      resolve(data);
    })
  }

  // Has cache but timeout
  if (!isValid(cache.get(key)?.time, cache.get(key)?.timeExpired)) {
    cache.delete(key);

    const data: T = await fetchCallback();

    if (data != null) {
      cache.set(key, {
        time: Date.now(),
        timeExpired: timeExpired,
        data: data
      });
    }

    AppLog.cache("Hit cache timeout, recall data");

    return new Promise((resolve, _) => {
      resolve(data);
    })
  }

  // Has cache
  const data = cache.get(key)?.data!;

  AppLog.cache("Hit cache");

  return new Promise((resolve, _) => {
    resolve(data);
  });
}

export function invalidateCache(key: string) {
  AppLog.cache("Invalidate cache id " + key);
  cache.delete(key);
}
