# MG2
## Devlog

In my MG2 breakdown, I roughly divided the player, coin, ground, and UI, as well as the associated point/score system. It includes what components are generally required for each category, as well as how these components will interact with each other. Then, in the actual production of minigame2, some additional adjustments were made to certain details, but overall it was still divided into player, coin, UI/Score and the coin spawner.<br><br>

**Player Object:** My `Player.cs` script implements the player's jump capability through `jumpForce = 8f` and the `isGrounded` boolean. The Jump [Space] action in `Update()` uses `Input.GetKeyDown(KeyCode.Space) && isGrounded`, then executes `rb.velocity = new Vector2(rb.velocity.x, jumpForce)` for vertical movement.

(To ensure the player could only jump when grounded, I carefully managed the `isGrounded` flag. It's set to `true` in `OnCollisionEnter2D()` when colliding with objects tagged "Ground", and would remain true until leaving ground contact. This strict check prevents mid-air jumping as required by the assignment.)

I also implemented `rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation` in Start() to lock the player's horizontal position, focusing gameplay on precise jump timing.<br><br>


**Coin Object:** The Coin's movement is handled by `CoinMovement.cs` with `moveSpeed = 3f`. Each frame, Update() calls `transform.Translate(-moveSpeed * Time.deltaTime, 0, 0)` for consistent leftward motion at 3 units per second. To prevent memory issues in infinite gameplay, coins automatically destroy themselves when `transform.position.x < -25f` using `Destroy(gameObject)`.

(To ensure proper collision detection, I configured the Coin's CircleCollider2D as a Trigger in Unity. This allows the player to pass through coins while still detecting collisions for scoring. I also set the Coin's tag to "Coin" for accurate identification in collision checks.)<br><br>


**UI/Score Display:** My `PlayerCollect.cs` script on the Player GameObject manages the score system. I chose TextMeshPro over traditional UI Text, so the script references `TMP_Text scoreText`. The UpdateScoreUI() method updates the display with `scoreText.text = "Score: " + score`, providing real-time feedback. The Canvas contains a TextMeshPro element anchored to the top-left corner showing continuous score updates.<br><br>


**Coin Spawner:** The `CoinSpawner.cs` script creates coins at irregular intervals using `Random.Range(0.5f, 2.0f)` within the SpawnCoins() coroutine. Each coin spawns at fixed coordinates `new Vector2(15f, 1.5f)` via `Instantiate(coinPrefab, spawnPosition, Quaternion.identity)`. The 'while (true)' loop with `yield return new WaitForSeconds(waitTime)` ensures continuous generation for infinite gameplay.

(I started with an immediate SpawnCoin() call before entering the infinite loop to give players an early coin target. The random interval between 0.5-2.0 seconds creates the "not-perfectly-regular" pattern specified in the requirements.)


## Open-Source Assets
- [Sprout Lands sprite asset pack](https://cupnooble.itch.io/sprout-lands-asset-pack) - rabbit and item sprites
- [Pixel Penguin 32x32 Asset pack](https://legends-games.itch.io/pixel-penguin-32x32-asset-pack) - penguin sprites
- [Coins 2D](https://artist2d3d.itch.io/2d) - coin sprites
