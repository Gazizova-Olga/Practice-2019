
var requestAnimFrame = (function () {
    return window.requestAnimationFrame ||
        window.webkitRequestAnimationFrame ||
        window.mozRequestAnimationFrame ||
        window.oRequestAnimationFrame ||
        window.msRequestAnimationFrame ||
        function (callback) {
            window.setTimeout(callback, 1000 / 60);
        };
})();

// Create the canvas
var canvas = document.createElement("canvas");
var ctx = canvas.getContext("2d");
canvas.width = 512;
canvas.height = 480;
document.body.appendChild(canvas);

// The main game loop
var lastTime;
function main() {
    var now = Date.now();
    var dt = (now - lastTime) / 1000.0;

    update(dt);
    render();

    lastTime = now;
    requestAnimFrame(main);
};

function init() {
    terrainPattern = ctx.createPattern(resources.get('img/terrain.png'), 'repeat');

    document.getElementById('play-again').addEventListener('click', function () {
        reset();
    });

    reset();
    lastTime = Date.now();
    main();
}

resources.load([
    'img/sprites_02.png',
    'img/terrain.png'
]);
resources.onReady(init);

// Game state
var player = {
    pos: [0, 0],
    sprite: new Sprite('img/sprites_02.png', [0, 0], [39, 39], 16, [0, 1])
};

var bullets = [];
var enemies = [];
var explosions = [];
var megaliths = [];
var manna = [];

var lastFire = Date.now();
var lastRespOfManna = Date.now();
var gameTime = 0;
var isGameOver;
var terrainPattern;

var score = 0;
var scoreEl = document.getElementById('score');

var scoreManna = 0;
var scoreElManna = document.getElementById('scoreManna');

// Speed in pixels per second
var playerSpeed = 200;
var bulletSpeed = 500;
var enemySpeed = 100;

// Update game objects
function update(dt) {
    gameTime += dt;

    handleInput(dt);
    updateEntities(dt);

    // It gets harder over time by adding enemies using this
    // equation: 1-.993^gameTime
    if (Math.random() < 1 - Math.pow(.993, gameTime)) {
        enemies.push({
            pos: [canvas.width, Math.random() * (canvas.height - 39)],
            sprite: new Sprite('img/sprites_02.png', [0, 78], [80, 39], 6, [0, 1, 2, 3, 2, 1]),
            trapIndex: 0
        });
    }

    if (manna.length < 12 && Date.now() - lastRespOfManna >= 5000) {
        respManna();
    }

    checkCollisions();
    scoreEl.innerHTML = score;
    scoreElManna.innerHTML = scoreManna;
};

function handleInput(dt) {
    if (input.isDown('DOWN') || input.isDown('s')) {
        player.pos[1] += playerSpeed * dt;
        if (checkCollisionsPlayerAndMegaliths()) {
            gameOver();
        }
    }

    if (input.isDown('UP') || input.isDown('w')) {
        player.pos[1] -= playerSpeed * dt;
        if (checkCollisionsPlayerAndMegaliths()) {
            gameOver();
        }
    }

    if (input.isDown('LEFT') || input.isDown('a')) {
        player.pos[0] -= playerSpeed * dt;
        if (checkCollisionsPlayerAndMegaliths()) {
            gameOver();
        }
    }

    if (input.isDown('RIGHT') || input.isDown('d')) {
        player.pos[0] += playerSpeed * dt;
        if (checkCollisionsPlayerAndMegaliths()) {
            gameOver();
        }
    }

    if (input.isDown('SPACE') &&
        !isGameOver &&
        Date.now() - lastFire > 100) {
        var x = player.pos[0] + player.sprite.size[0] / 2;
        var y = player.pos[1] + player.sprite.size[1] / 2;

        bullets.push({
            pos: [x, y],
            dir: 'forward',
            sprite: new Sprite('img/sprites_02.png', [0, 39], [18, 8])
        });
        bullets.push({
            pos: [x, y],
            dir: 'up',
            sprite: new Sprite('img/sprites_02.png', [0, 50], [9, 5])
        });
        bullets.push({
            pos: [x, y],
            dir: 'down',
            sprite: new Sprite('img/sprites_02.png', [0, 60], [9, 5])
        });

        lastFire = Date.now();
    }
}

function checkCollisionsPlayerAndMegaliths() {
    for (var i = 0; i < megaliths.length; i++) {
        var pos = megaliths[i].pos;
        var size = megaliths[i].sprite.size;
        if (boxCollides(pos, size, player.pos, player.sprite.size)) {
            return true;
        };
    }
}



function updateEntities(dt) {
    // Update the player sprite animation
    player.sprite.update(dt);

    // Update all the bullets
    for (var i = 0; i < bullets.length; i++) {
        var bullet = bullets[i];

        switch (bullet.dir) {
            case 'up':
                bullet.pos[1] -= bulletSpeed * dt;
                break;
            case 'down':
                bullet.pos[1] += bulletSpeed * dt;
                break;
            default:
                bullet.pos[0] += bulletSpeed * dt;
        }

        // Remove the bullet if it goes offscreen
        if (bullet.pos[1] < 0 || bullet.pos[1] > canvas.height ||
            bullet.pos[0] > canvas.width) {
            bullets.splice(i, 1);
            i--;
        }
    }

    // Update all the enemies
    for (var i = 0; i < enemies.length; i++) {
        var pos = enemies[i].pos;
        var size = enemies[i].sprite.size;
        enemies[i].pos[0] -= enemySpeed * dt;

        for (var j = 0; j < megaliths.length; j++) {
            if (boxCollides(pos, size, megaliths[j].pos, megaliths[j].sprite.size)) {
                enemies[i].pos[0] += enemySpeed * dt;
                if (enemies[i].dir == "UP") {
                    enemies[i].pos[1] -= enemySpeed * dt;
                } else {
                    if (enemies[i].dir == "DOWN") {
                        enemies[i].pos[1] += enemySpeed * dt;
                    } else {
                        enemies[i].dir = "UP";
                        enemies[i].pos[1] -= enemySpeed * dt;
                    }
                }
                for (var k = 0; k < megaliths.length; k++) {

                    if (boxCollides(pos, size, megaliths[k].pos, megaliths[k].sprite.size)) {

                        if (enemies[i].dir == "UP") {
                            enemies[i].pos[1] += 4 * enemySpeed * dt;
                            enemies[i].dir = "DOWN";
                            enemies[i].trapIndex += 1;
                        } else {
                            if (enemies[i].dir == "DOWN") {
                                enemies[i].pos[1] -= 4 * enemySpeed * dt;
                                enemies[i].dir = "UP";
                                enemies[i].trapIndex += 1;
                            }
                        }
                        break;
                    }
                }
            }
        }
        if (enemies[i].trapIndex > 16) {
            enemies.splice(i, 1);
            i--;
            explosions.push({
                pos: pos,
                sprite: new Sprite('img/sprites_02.png',
                    [0, 117],
                    [39, 39],
                    16,
                    [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12],
                    null,
                    true)
            });
        }
        else {

            enemies[i].sprite.update(dt);

            // Remove if offscreen
            if (enemies[i].pos[0] + enemies[i].sprite.size[0] < 0) {
                enemies.splice(i, 1);
                i--;
            }
        }
    }

    // Update all the explosions
    for (var i = 0; i < explosions.length; i++) {
        explosions[i].sprite.update(dt);

        // Remove if animation is done
        if (explosions[i].sprite.done) {
            explosions.splice(i, 1);
            i--;
        }
    }
    //update manna
   /*for (var i = 0; i < manna.length; i++) {
        manna[i].sprite.update(dt);
    }*/

    /*for (var i = 0; i < mannaExplosions.length; i++) {
        mannaExplosions[i].sprite.update(dt);
        if (mannaExplosions[i].sprite.done) {
            mannaExplosions.splice(i, 1);
            i--;
        }
    }*/
    for (var i = 0; i < manna.length; i++) {
        var pos = manna[i].pos;
        var size = manna[i].sprite.size;
        manna[i].sprite.update(dt);
        if (boxCollides(pos, size, player.pos, player.sprite.size) && !manna[i].sprite.touch) {
            manna[i].sprite.changeAnimation([0, 1, 2, 3]);
            scoreManna++;
        }
        if(manna[i].sprite.done) {
            manna.splice(i, 1);
            i--;
        }
    }
}

// Collisions

function collides(x, y, r, b, x2, y2, r2, b2) {
    return !(r <= x2 || x > r2 ||
        b <= y2 || y > b2);
}

function boxCollides(pos, size, pos2, size2) {
    return collides(pos[0], pos[1],
        pos[0] + size[0], pos[1] + size[1],
        pos2[0], pos2[1],
        pos2[0] + size2[0], pos2[1] + size2[1]);
}

function checkCollisions() {
    checkPlayerBounds();

    // Run collision detection for all enemies and bullets
    for (var i = 0; i < enemies.length; i++) {
        var pos = enemies[i].pos;
        var size = enemies[i].sprite.size;

        for (var j = 0; j < bullets.length; j++) {
            var pos2 = bullets[j].pos;
            var size2 = bullets[j].sprite.size;

            if (boxCollides(pos, size, pos2, size2)) {
                // Remove the enemy
                enemies.splice(i, 1);
                i--;

                // Add score
                score += 100;

                // Add an explosion
                explosions.push({
                    pos: pos,
                    sprite: new Sprite('img/sprites_02.png',
                        [0, 117],
                        [39, 39],
                        16,
                        [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12],
                        null,
                        true)
                });

                // Remove the bullet and stop this iteration
                bullets.splice(j, 1);
                break;
            }
        }

        if (boxCollides(pos, size, player.pos, player.sprite.size)) {
            gameOver();
        }
    }
    // Run collision detection for all megaliths and bullets
    for (var i = 0; i < megaliths.length; i++) {
        var pos = megaliths[i].pos;
        var size = megaliths[i].sprite.size;

        for (var j = 0; j < bullets.length; j++) {
            var pos2 = bullets[j].pos;
            var size2 = bullets[j].sprite.size;

            if (boxCollides(pos, size, pos2, size2)) {
                bullets.splice(j, 1);
                break;
            }
        }
    }
}

function checkPlayerBounds() {
    // Check bounds
    if (player.pos[0] < 0) {
        player.pos[0] = 0;
    }
    else if (player.pos[0] > canvas.width - player.sprite.size[0]) {
        player.pos[0] = canvas.width - player.sprite.size[0];
    }

    if (player.pos[1] < 0) {
        player.pos[1] = 0;
    }
    else if (player.pos[1] > canvas.height - player.sprite.size[1]) {
        player.pos[1] = canvas.height - player.sprite.size[1];
    }
}

// Draw everything
function render() {
    ctx.fillStyle = terrainPattern;
    ctx.fillRect(0, 0, canvas.width, canvas.height);

    // Render the player if the game isn't over
    if (!isGameOver) {
        renderEntity(player);
    }

    renderEntities(bullets);
    renderEntities(enemies);
    renderEntities(explosions);
    renderEntities(megaliths);
    renderEntities(manna);
};

function renderEntities(list) {
    for (var i = 0; i < list.length; i++) {
        renderEntity(list[i]);
    }
}

function renderEntity(entity) {
    ctx.save();
    ctx.translate(entity.pos[0], entity.pos[1]);
    entity.sprite.render(ctx);
    ctx.restore();
}

function respManna() {
    manna.push({
        pos: [Math.floor(Math.random() * (canvas.width - 58 + 1)),
        Math.floor(Math.random() * (canvas.height - 50 + 1))
        ],
        sprite: new Sprite('img/sprites_02.png', [0, 160], [58, 50], 4, [0, 1])
    });


    for (var j = 0; j < manna.length - 1; j++) {
        if (boxCollides(manna[manna.length - 1].pos, manna[manna.length - 1].sprite.size, manna[j].pos, manna[j].sprite.size)) {
            manna.pop();
            return false;
        }
    }

    for (var j = 0; j < megaliths.length; j++) {
        if (boxCollides(manna[manna.length - 1].pos, manna[manna.length - 1].sprite.size, megaliths[j].pos, megaliths[j].sprite.size)) {
            manna.pop();
            return false;
        }
    }

    if (boxCollides(manna[manna.length - 1].pos, manna[manna.length - 1].sprite.size, player.pos, player.sprite.size)) {
        manna.pop();
        return false;
    }
    lastRespOfManna = Date.now();
    return true;
}

// Game over
function gameOver() {
    document.getElementById('game-over').style.display = 'block';
    document.getElementById('game-over-overlay').style.display = 'block';
    isGameOver = true;
}

// Reset game to original state
function reset() {
    document.getElementById('game-over').style.display = 'none';
    document.getElementById('game-over-overlay').style.display = 'none';
    isGameOver = false;
    gameTime = 0;
    score = 0;

    enemies = [];
    bullets = [];
    megaliths = [];
    manna = [];

    player.pos = [50, canvas.height / 2];

    var min = 4;
    var max = 6;

    var countOfMegaliths = Math.floor(min + Math.random() * (max + 1 - min));

    for (var i = 0; i < countOfMegaliths; i++) {
        if (i < 2) {
            megaliths.push({
                pos: [Math.floor(Math.random() * (canvas.width - 60 + 1)),
                Math.floor(Math.random() * (canvas.height - 55 + 1))
                ],
                sprite: new Sprite('img/sprites_02.png', [0, 212], [60, 55])
            });
        } else {
            megaliths.push({
                pos: [Math.floor(Math.random() * (canvas.width - 56 + 1)),
                Math.floor(Math.random() * (canvas.height - 47 + 1))
                ],
                sprite: new Sprite('img/sprites_02.png', [0, 271], [56, 47])
            });
        }
        //collisions of megaliths with player
        if (boxCollides(megaliths[megaliths.length - 1].pos, megaliths[megaliths.length - 1].sprite.size, player.pos, player.sprite.size)) {
            megaliths.pop();
            i--;
            continue;
        }
        //megaliths overlaps
        for (var j = 0; j < megaliths.length - 1; j++) {
            if (boxCollides(megaliths[megaliths.length - 1].pos, megaliths[megaliths.length - 1].sprite.size, megaliths[j].pos, megaliths[j].sprite.size)) {
                megaliths.pop();
                i--;
                break;
            }
        }
    }
    var randManna = Math.floor(4 + Math.random() * 9);
    while (manna.length < randManna) {
        respManna();
    }
};