const getSolution = (array, target) => {
    let left = 0;
    let right = array.length

    while(left <= right){
        let mid = Math.floor((right - left) / 2);
        if(mid < target){
            left = mid + 1;
        }
        else if (mid > target){
            right = mid - 1;
        }
        else {
            return mid;
        }
    } return -1;
}